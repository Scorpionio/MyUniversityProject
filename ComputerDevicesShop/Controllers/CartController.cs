using ComputerDevicesShop.Data;
using ComputerDevicesShop.Models;
using ComputerDevicesShop.Models.DTOs;
using ComputerDevicesShop.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace ComputerDevicesShop.Controllers
{
    public class CartController : Controller
    {
        private const string CookieName = "UserAuth";
        private readonly ICartRepository _cartRepo;
        ApplicationDbContext _db;

        public CartController(ApplicationDbContext context, ICartRepository cartRepo)
        {
            _db = context;
            _cartRepo = cartRepo;
        }
        public async Task<IActionResult> UserCart()
        {
            if (Request.Cookies.TryGetValue(CookieName, out string username))
            {
                ViewBag.UserAuth = username;
            }
            var shoppingCart = await _cartRepo.GetUserCart();
            return View(shoppingCart);
        }

        public async Task<IActionResult> AddItem(int id, int qty = 1, int redirect = 1)
        {
            var cartCount = await _cartRepo.AddItem(id, qty);
            if (redirect == 0)
                return Ok(cartCount);
            return RedirectToAction("UserCart", "Cart");
        }

        public async Task<IActionResult> DeleteItem(int id, int qty = 1, int redirect = 1)
        {
            var cartCount = await _cartRepo.DeleteItem(id, qty);
            if (redirect == 0)
                return Ok(cartCount);
            return RedirectToAction("UserCart", "Cart");
        }

        //cheakout

        public IActionResult Checkout() {
            if (Request.Cookies.TryGetValue(CookieName, out string username))
            {
                ViewBag.UserAuth = username;
            }
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            int? orderId = await _cartRepo.CreateOrder(model);
            if (orderId == null)
                return RedirectToAction(nameof(OrderFail));
            return RedirectToAction(nameof(OrderSuccess), new { id = orderId });
        }

        public IActionResult OrderSuccess(int id) {
            Console.WriteLine($"OrderSuccess {id}");
            ViewBag.OrderId = id;
            return View();   
        }

        public IActionResult OrderFail()
        {
            return View();
        }

        //cheak

        [HttpGet]
        public async Task<IActionResult> DownloadReceipt(int id) // id — OrderId
        {
            var order = await _db.Orders
                .Include(o => o.OrderDetail)
                .ThenInclude(od => od.Device)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
                return NotFound();

            var sb = new StringBuilder();
            sb.AppendLine("======================================");
            sb.AppendLine("  МАГАЗИН КОМПЬЮТЕРНЫХ КОМПЛЕКТУЮЩИХ");
            sb.AppendLine("               ЧЕК ОПЛАТЫ");
            sb.AppendLine("======================================");
            sb.AppendLine("Дата: " + DateTime.Now.ToString("yyyy-MM-dd"));
            sb.AppendLine("Время: " + DateTime.Now.ToString("HH:mm:ss"));
            sb.AppendLine("--------------------------------------");

            decimal totalAmount = 0;

            foreach (var item in order.OrderDetail)
            {
                var name = item.Device.Name.Length > 38
                    ? item.Device.Name.Substring(0, 35) + "…"
                    : item.Device.Name;

                decimal itemTotal = (decimal)item.UnitPrice * item.Quantity;
                totalAmount += itemTotal;

                sb.AppendLine(name);
                sb.AppendLine($"{item.UnitPrice,29:F2} x{item.Quantity,2} = {itemTotal,7:F2}");
            }

            sb.AppendLine("--------------------------------------");
            sb.AppendLine($"Итого:{totalAmount,30:F2}");
            sb.AppendLine("======================================");
            sb.AppendLine("      Благодарим за покупку!");
            sb.AppendLine("======================================");

            var bytes = Encoding.UTF8.GetBytes(sb.ToString());
            var stream = new MemoryStream(bytes);
            var fileName = $"receipt_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            return File(stream, "text/plain", fileName);
        }


    }
}
