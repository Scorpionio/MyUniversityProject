using ComputerDevicesShop.Models;

namespace ComputerDevicesShop.Repositories
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Device>> GetDevices(string? sTerm, int categoryId, string? sortInfo);
        Task<IEnumerable<Category>> Categories();
    }
}
