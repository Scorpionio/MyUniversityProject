using ComputerDevicesShop.Data;
using ComputerDevicesShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerDevicesShop.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public const string CookieName = "UserAuth";
        private ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrderRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _db = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<Order>> ViewUserOrder() {
            int userId = GetUserId();
            var orders = _db.Orders.Include(o => o.OrderStatus)
                                    .Include(o => o.OrderDetail)
                                    .ThenInclude(o => o.Device)
                                    .ThenInclude(o => o.Category)
                                    .Where(o => o.UserId == userId)
                                    .AsQueryable();

            return await orders.ToListAsync();
        }

        public int GetUserId()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context != null && context.Request.Cookies.TryGetValue("UserAuth", out var CookieName))
            {
                User user = _db.Users.FirstOrDefault(u => u.Name == CookieName);
                return user.UserId;
            }
            return 0;
        }
    }
}
