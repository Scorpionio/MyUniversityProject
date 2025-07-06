using ComputerDevicesShop.Models;
using ComputerDevicesShop.Models.DTOs;

namespace ComputerDevicesShop.Repositories
{
    public interface ICartRepository
    {
        Task<int> AddItem(int deciceId, int quantity);
        Task<int> DeleteItem(int deviceId, int quantity);
        Task<int> GetCartItemCount(int userId = 0);
        Task<Cart> GetCart(int userId);
        Task<Cart> GetUserCart();
        Task<int?> CreateOrder(CheckoutModel model);
        int GetUserId();
    }
}
