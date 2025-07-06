namespace ComputerDevicesShop.Models.DTOs
{
    public class DetailDTO
    {
        public Device Device { get; set; }
        public string CategoryName { get; set; }
        public List<Rate>? Rates { get; set; }
        public User? User { get; set; }
    }
}
