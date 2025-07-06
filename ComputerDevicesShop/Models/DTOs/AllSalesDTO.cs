namespace ComputerDevicesShop.Models.DTOs
{
    public class AllSalesDTO
    {
        public IEnumerable<Order> Orders { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
