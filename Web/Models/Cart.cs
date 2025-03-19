namespace Web.Models
{
    public class Cart
    {
		public int id { get; set; }
		public List<CartItem> CartItems { get; set; }
		public decimal? TotalPrice { get; set; }
		public int? TotalQuantity { get; set; }
	}
}
