namespace ComputerDevicesShop.Models.DTOs
{
    public class DeviceSalesInfo
    {
        public Device Device { get; set; }
        public int TotalQuantity { get; set; }
        public double TotalRevenue { get; set; }
        public double? Rate { get; set; }
    }
}
