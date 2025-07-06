namespace ComputerDevicesShop.Models.DTOs
{
    public class GoodsInfoDTO
    {
        public IEnumerable<DeviceSalesInfo> DevicesInfo { get; set; }
        public string SortValue { get; set; }
    }
}
