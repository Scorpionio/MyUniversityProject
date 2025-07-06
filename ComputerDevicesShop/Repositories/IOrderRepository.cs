using ComputerDevicesShop.Models;

namespace ComputerDevicesShop.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> ViewUserOrder();
        int GetUserId();
    }
}
