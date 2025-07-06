using ComputerDevicesShop.Data;
using ComputerDevicesShop.Models;
using ComputerDevicesShop.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ComputerDevicesShop.Controllers
{
    public class OrderController : Controller
    {

        public const string CookieName = "UserAuth";
        private ApplicationDbContext _db;
        private readonly IOrderRepository _orderRepository;

        public OrderController(ApplicationDbContext context, IOrderRepository orderRepository)
        {
            _db = context;
            _orderRepository = orderRepository;
        }

        public async Task<IActionResult> OrdersList()
        {
            if (Request.Cookies.TryGetValue(CookieName, out string username))
            {
                ViewBag.UserAuth = username;
            }
            var userOrder = await _orderRepository.ViewUserOrder();
            return View(userOrder);
        }

        [HttpPost]
        public async Task<IActionResult> ReturnOrder(int id)
        {
            if (Request.Cookies.TryGetValue(CookieName, out string username))
            {
                ViewBag.UserAuth = username;
            }
            var order = await _db.Orders
                            .Include(o => o.OrderDetail)
                            .ThenInclude(od => od.Device)
                            .ThenInclude(d => d.Stock)
                            .FirstOrDefaultAsync(o => o.OrderId == id);
            if (order != null)
            {
                order.OrderStatusId = 3; // например, 3 = "Отменено"
                foreach (var item in order.OrderDetail)
                {
                    item.Device.Stock.Count += item.Quantity;
                }
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("OrdersList", "Order");
        }
    }
}
