using ComputerDevicesShop.Data;
using ComputerDevicesShop.Models;
using ComputerDevicesShop.Models.DTOs;
using ComputerDevicesShop.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ComputerDevicesShop.Controllers
{
    public class AdminController : Controller
    {
        public const string CookieName = "UserAuth";
        private ApplicationDbContext _db;
        private readonly IAdminRepository _adminRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AdminController(ApplicationDbContext context, IAdminRepository adminRepository, IHttpContextAccessor httpContextAccessor)
        {
            _db = context;
            _adminRepository = adminRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult AdminPage()
        {
            if (Request.Cookies.TryGetValue(CookieName, out string username))
            {
                ViewBag.UserAuth = username;
            }
            return View();
        }

        public IActionResult DeviceAddedSuccess() {
            return View(); 
        }

        [HttpGet]
        public IActionResult AddDevice()
        {
            if (Request.Cookies.TryGetValue(CookieName, out string username))
            {
                ViewBag.UserAuth = username;
            }
            var model = new AddDeviceModel
            {
                Name = "",
                Price = 0,
                Description = "",
                Image = null
            };
            IEnumerable<Category> categories = _db.Categories.ToList();

            var newModel = new AddDeviceDTO
            {
                AddDeviceModel = model,
                Categories = categories,
                CategoryId = 0
            };
            return View(newModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddDevice(AddDeviceDTO dto, int categoryId) {
            var model = dto.AddDeviceModel;
            ModelState.Remove("Categories");
            // DEBUG: выводим поля
            Console.WriteLine($"Name: {model.Name}");
            Console.WriteLine($"Price: {model.Price}");
            Console.WriteLine($"Description: {model.Description}");
            Console.WriteLine($"Image: {(model.Image == null ? "null" : model.Image.FileName)}");
            Console.WriteLine($"CategoryId: {categoryId}");

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine("ModelState error: " + error.ErrorMessage);
                }
            }

            if (!double.TryParse(model.Price.ToString(), System.Globalization.NumberStyles.Any,
            System.Globalization.CultureInfo.InvariantCulture, out double parsedPrice))
            {
                ModelState.AddModelError("AddDeviceModel.Price", "Некорректный формат цены");
            }

            if (categoryId == 0) {
                ModelState.AddModelError("", "Категория не выбрана");
            }

            if (TryValidateModel(model)) {
                Device device = await _db.Devices.FirstOrDefaultAsync(d => d.Name == model.Name);
                if (device == null)
                {
                    _db.Devices.Add(new Device { 
                        CategoryId = categoryId,
                        Name = model.Name,
                        Price = model.Price,
                        Description = model.Description,
                        Image = null,
                        Rate = 0
                    });
                    await _db.SaveChangesAsync();
                    return RedirectToAction("DeviceAddedSuccess", "Admin");
                } else
                {
                    ModelState.AddModelError("", "Товар с таким именем уже существует");
                }
            }

            IEnumerable<Category> categories = _db.Categories.ToList();

            var newModel = new AddDeviceDTO
            {
                AddDeviceModel = model,
                Categories = categories,
                CategoryId = categoryId
            };

            return View(newModel);
        }


        //Goods Info
        public async Task<IActionResult> GoodsInfo(string sortValue)
        {
            if (Request.Cookies.TryGetValue(CookieName, out string username))
            {
                ViewBag.UserAuth = username;
            }
            List<DeviceSalesInfo> deviceSalesInfo = await _adminRepository.GoodsInfo(sortValue);


            var model = new GoodsInfoDTO
            {
                DevicesInfo = deviceSalesInfo,
                SortValue = sortValue
            };

            return View(model);
        }

        //AddGoods

        [HttpGet]
        public async Task<IActionResult> AddGoods(int value, int StockId)
        {
            if (Request.Cookies.TryGetValue(CookieName, out string username))
            {
                ViewBag.UserAuth = username;
            }
            IEnumerable<Stock> stocks = await _adminRepository.AddGoods(value, StockId);
            var model = new AddGoods
            {
                Stocks = stocks,
                Value = value,
                StockId = StockId
            };
            return View(model);
        }

        //ChangeItem

        [HttpGet]
        public async Task<IActionResult> ChangeItem(int id)
        {
            if (Request.Cookies.TryGetValue(CookieName, out string username))
            {
                ViewBag.UserAuth = username;
            }
            Device device = await _db.Devices.FirstOrDefaultAsync(d => d.DeviceId == id);
            ViewBag.DeviceId = device.DeviceId;
            IEnumerable<Category> categories = _db.Categories.ToList();
            var model = new AddDeviceModel
            {
                Name = device.Name,
                Price = device.Price,
                Description = device.Description,
                Image = null
            };
            var dtoModel = new AddDeviceDTO
            {
                AddDeviceModel = model,
                Categories = categories,
                CategoryId = device.CategoryId
            };
            return View(dtoModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeItem(AddDeviceDTO dto, int categoryId, int id)
        {
            if (Request.Cookies.TryGetValue(CookieName, out string username))
            {
                ViewBag.UserAuth = username;
            }

            var model = dto.AddDeviceModel;
            if (!TryValidateModel(model))
            {
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        Console.WriteLine($"{entry.Key}: {error.ErrorMessage}");
                    }
                }
            }
            //if (TryValidateModel(model))
            //{
            //    foreach (var entry in ModelState)
            //    {
            //        foreach (var error in entry.Value.Errors)
            //        {
            //            Console.WriteLine($"{entry.Key}: {error.ErrorMessage}");
            //        }
            //    }
            //}
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine("ModelState error: " + error.ErrorMessage);
                }
            }
            if (!double.TryParse(model.Price.ToString(), System.Globalization.NumberStyles.Any,
            System.Globalization.CultureInfo.InvariantCulture, out double parsedPrice))
            {
                ModelState.AddModelError("AddDeviceModel.Price", "Некорректный формат цены");
            }
            if (TryValidateModel(model))
            { 
                Device device = await _db.Devices.FirstOrDefaultAsync(d => d.DeviceId == id);
                device.Name = model.Name;
                device.Price = model.Price;
                device.Description = model.Description;
                device.Image = null;
                Console.WriteLine(model.Name);
                Console.WriteLine(model.Price);
                Console.WriteLine(model.Description);
                Console.WriteLine(model.Image);
                Console.WriteLine(device.Name);
                Console.WriteLine(device.Price);
                Console.WriteLine(device.Description);
                Console.WriteLine(device.Image);
                await _db.SaveChangesAsync();
                return RedirectToAction("DeviceChangeSuccess", "Admin");
            }
            IEnumerable<Category> categories = _db.Categories.ToList();

            var dtoModel = new AddDeviceDTO
            {
                AddDeviceModel = model,
                Categories = categories,
                CategoryId = categoryId
            };

            return View(dtoModel);
        }

        public IActionResult DeviceChangeSuccess() {
            return View();
        }

        //DeleteItem

        public async Task<IActionResult> DeleteItem(int id)
        {
            if (Request.Cookies.TryGetValue(CookieName, out string username))
            {
                ViewBag.UserAuth = username;
            }
            Device device = await _db.Devices.FirstOrDefaultAsync(d => d.DeviceId == id);
            _db.Devices.Remove(device);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }


        //AllSales
        public async Task<IActionResult> AllSales(DateTime? dateTo, DateTime? dateFrom)
        {
            if (Request.Cookies.TryGetValue(CookieName, out string username))
            {
                ViewBag.UserAuth = username;
            }
            IEnumerable <Order> sales = await _adminRepository.AllSales(dateTo, dateFrom);
            var model = new AllSalesDTO
            {
                Orders = sales,
                DateTo = dateTo ?? DateTime.UtcNow.Date,
                DateFrom = dateFrom ?? DateTime.UtcNow.Date
            };
            return View(model);
        }

        //UserManagement

        [HttpGet]
        public IActionResult UserManagement(AddAdminModel model)
        {
            if (Request.Cookies.TryGetValue(CookieName, out string username))
            {
                ViewBag.UserAuth = username;
            }
            var context = _httpContextAccessor.HttpContext;
            context.Request.Cookies.TryGetValue("UserAuth", out var CookieRole);
            User user = _db.Users.FirstOrDefault(u => u.Name == CookieRole);
            var userModel = new ProfileRole
            {
                User = user
            };
            var dto = new UserManagementDTO
            {
                DoAdminModel = new DoAdminModel(),
                AddAdminModel = new AddAdminModel { 
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword,
                },
                DeleteUserModel = new DeleteUserModel(),
                ProfileRole = userModel
            };
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UserToAdmin(UserManagementDTO dto)
        {
            var model = dto.DoAdminModel;
            User user = await _db.Users.FirstOrDefaultAsync(u => u.Email == model.UserToAdminEmail);
            if (user != null)
            {
                user.RoleId = 2;
                await _db.SaveChangesAsync();
            }
            else {
                ModelState.AddModelError("", "Пользователь не найден");
            }
                return RedirectToAction("UserManagement");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(UserManagementDTO dto)
        {
            var model = dto.AddAdminModel;
            if (ModelState.IsValid)
            {
                User user = await _db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Name == model.Name);
                if (user == null)
                {
                    _db.Users.Add(new User { Name = model.Name, Email = model.Email, Password = model.Password, RoleId = 2 });
                    await _db.SaveChangesAsync();
                    User userId = await _db.Users.FirstOrDefaultAsync(ui => ui.Email == model.Email);
                    var cart = new Cart
                    {
                        UserId = userId.UserId
                    };
                    _db.Carts.Add(cart);
                    await _db.SaveChangesAsync();

                    return RedirectToAction("UserManagement");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }

            return RedirectToAction("UserManagement", model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(UserManagementDTO dto)
        {
            var model = dto.DeleteUserModel;
            User user = await _db.Users.FirstOrDefaultAsync(u => u.Email == model.DeleteUserEmail);
            if (user != null)
            {
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
            }
            else
            {
                ModelState.AddModelError("", "Пользователь не найден");
            }
            return RedirectToAction("UserManagement");
        }

        public IActionResult DeleteUser()
        {
            if (Request.Cookies.TryGetValue(CookieName, out string username))
            {
                ViewBag.UserAuth = username;
            }
            return View();
        }
    }
}
