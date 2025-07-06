namespace ComputerDevicesShop.Models.DTOs
{
    public class AddGoods
    {
        public IEnumerable<Stock> Stocks { get; set; }
        public int Value { get; set; }
        public int StockId { get; set; }
    }
}
