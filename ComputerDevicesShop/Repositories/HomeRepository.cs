using ComputerDevicesShop.Data;
using ComputerDevicesShop.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ComputerDevicesShop.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private const string CookieName = "UserAuth";
        ApplicationDbContext _db;

        public HomeRepository(ApplicationDbContext context)
        {
            _db = context;
        }
        public async Task<IEnumerable<Category>> Categories()
        {
            return await _db.Categories.ToListAsync();
        }
        public async Task<IEnumerable<Device>> GetDevices(string? sTerm, int categoryId, string? sortInfo)
        {
            var query = _db.Devices.Include(d => d.Category).AsQueryable();

            if (!string.IsNullOrWhiteSpace(sTerm))
                query = query.Where(p => p.Name.Contains(sTerm));

            if (categoryId > 0)
                query = query.Where(p => p.CategoryId == categoryId);


            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
                double average = _db.Rates
                                    .AsEnumerable() // переходим на выполнение в C#
                                    .Where(r => r.DeviceId == item.DeviceId)
                                    .Select(r => r.Rateing)
                                    .DefaultIfEmpty(0)
                                    .Average();
                item.Rate = Math.Round(average, 1);
            }
            await _db.SaveChangesAsync();

            switch (sortInfo)
            {
                case "Standart":
                    query = query.OrderBy(p => p.DeviceId);
                    break;
                case "By_price_down":
                    query = query.OrderByDescending(p => p.Price);
                    break;
                case "By_price_up":
                    query = query.OrderBy(p => p.Price);
                    break;
                case "By_rate_down":
                    query = query.OrderByDescending(p => p.Rate);
                    break;
                case "By_rate_up":
                    query = query.OrderBy(p => p.Rate);
                    break;
                default:
                    query = query.OrderBy(p => p.DeviceId);
                    break;
            }
            return query;
        }
    }
}
