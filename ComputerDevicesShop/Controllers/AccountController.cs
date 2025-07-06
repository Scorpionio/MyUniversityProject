using ComputerDevicesShop.Data;
using ComputerDevicesShop.Models;
using ComputerDevicesShop.Models.DTOs;
using ComputerDevicesShop.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerDevicesShop.Controllers
{
    public class AccountController : Controller
    {
        public const string CookieName = "UserAuth";
        private ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _db = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

                //ИСПРАВИТЬ ПРОВЕРКУ НА ПАРОЛЬ
                if (user != null)
                {

                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTime.Now.AddHours(2), // Время жизни куки
                        HttpOnly = true
                    };
                    
                    Response.Cookies.Append(CookieName, user.Name, cookieOptions);
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {

            if (ModelState.IsValid) {
                User user = await _db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Name == model.Name);
                if (user == null)
                {
                    _db.Users.Add(new User { Name = model.Name, Email = model.Email, Password = model.Password, RoleId = 1 });
                    await _db.SaveChangesAsync();
                    User userId = await _db.Users.FirstOrDefaultAsync(ui => ui.Email == model.Email);
                    var cart = new Cart
                    {
                        UserId = userId.UserId
                    };
                    _db.Carts.Add(cart);
                    await _db.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        public IActionResult Logout() {
            Response.Cookies.Delete(CookieName);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Profile()
        {
            if (Request.Cookies.TryGetValue(CookieName, out string username))
            {
                ViewBag.UserAuth = username;
            }
            var context = _httpContextAccessor.HttpContext;
            context.Request.Cookies.TryGetValue("UserAuth", out var CookieRole);
            User user = _db.Users.FirstOrDefault(u => u.Name == CookieRole);
            var model = new ProfileRole
            {
                User = user
            };
            return View(model);
        }

    }
}
