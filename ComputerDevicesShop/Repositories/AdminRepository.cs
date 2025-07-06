using ComputerDevicesShop.Data;
using ComputerDevicesShop.Models;
using ComputerDevicesShop.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ComputerDevicesShop.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        public const string CookieName = "UserAuth";
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _db = context;
            _httpContextAccessor = httpContextAccessor;
        }

        //public async Task<> GetCategorys(int categoryId)
        //{

        //}

        public async Task<List<DeviceSalesInfo>> GoodsInfo(string sortValue) {
            List<DeviceSalesInfo> deviceInfoList = await _db.OrderDetails
                        .Include(od => od.Device)
                        .GroupBy(od => od.DeviceId)
                        .Select(g => new DeviceSalesInfo
                        {
                            Device = g.First().Device,
                            TotalQuantity = g.Sum(x => x.Quantity),
                            TotalRevenue = g.Sum(x => x.Quantity * x.UnitPrice),
                            Rate = g.First().Device.Rate
                        })
                        .ToListAsync();

            switch (sortValue)
            {
                case "Most_sale":
                    deviceInfoList = deviceInfoList
                        .OrderByDescending(x => x.TotalQuantity)
                        .ToList();
                    break;

                case "NotMost_sale":
                    deviceInfoList = deviceInfoList
                        .OrderBy(x => x.TotalQuantity)
                        .ToList();
                    break;

                case "Most_benefit":
                    deviceInfoList = deviceInfoList
                        .OrderByDescending(x => x.TotalRevenue)
                        .ToList();
                    break;

                case "NotMost_benefit":
                    deviceInfoList = deviceInfoList
                        .OrderBy(x => x.TotalRevenue)
                        .ToList();
                    break;

                case "High_rate":
                    deviceInfoList = deviceInfoList
                        .OrderByDescending(d => d.Rate ?? 0)
                        .ToList();
                    break;

                case "NotHigh_rate":
                    deviceInfoList = deviceInfoList
                        .OrderBy(d => d.Rate ?? 0)
                        .ToList();
                    break;

                default: // All_info
                    deviceInfoList = deviceInfoList.ToList();
                    break;
            }

            return deviceInfoList;
        }

        public async Task<IEnumerable<Stock>> AddGoods(int value, int StockId)
        {
            if (!(StockId == 0 && value <= 0)) { 
                var stock = _db.Stocks.FirstOrDefault(s => s.StockId == StockId);
                stock.Count += value;
                await _db.SaveChangesAsync();
            }
            return await _db.Stocks.Include(s => s.Device).ToListAsync();
        }

        public async Task<IEnumerable<Order>> AllSales(DateTime? dateTo, DateTime? dateFrom)
        {
            var orders = _db.Orders.Include(o => o.OrderStatus)
                                    .Include(o => o.OrderDetail)
                                    .ThenInclude(o => o.Device)
                                    .ThenInclude(o => o.Category)
                                    .AsQueryable();

            if (dateFrom.HasValue) { 
                orders = orders.Where(o => o.CreateDate >= dateFrom);
            } 
            if (dateTo.HasValue) {
                orders = orders.Where(o => o.CreateDate <= dateTo);
            }

            return await orders.ToListAsync();
        }


        public async Task<Cart> GetCart(int userId)
        {
            var userCart = await _db.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
            return userCart;
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
