using ComputerDevicesShop.Models;
using ComputerDevicesShop.Models.DTOs;

namespace ComputerDevicesShop.Repositories
{
    public interface IAdminRepository
    {
        Task<List<DeviceSalesInfo>> GoodsInfo(string sortValue);
        Task<IEnumerable<Order>> AllSales(DateTime? dateTo, DateTime? dateFrom);
        Task<IEnumerable<Stock>> AddGoods(int value, int StockId);
        
    }
}
