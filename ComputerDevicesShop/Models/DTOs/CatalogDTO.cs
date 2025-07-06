namespace ComputerDevicesShop.Models.DTOs
{
    public class CatalogDTO
    {
        public IEnumerable<Device> Devices { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string? STerm { get; set; }
        public int CategoryId { get; set; }
        public string? SortInfo { get; set; }
    }
}
