using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
	public class CartController : Controller
	{
		private readonly ApplicationDbContext db;
		private List<CartItem> _cartItems;
		public CartController(ApplicationDbContext db)
		{
			this.db = db;
			_cartItems = new List<CartItem>();
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult AddToCart(int id)
		{
			var deviceToAdd = db.Device.Find(id);

			var cartItems = HttpContext.Session.Get<List<CartItem>>("Cart") ?? new List<CartItem>();

			var existingCartItem = cartItems.FirstOrDefault(item => item.Device.Id == id);

			if (existingCartItem != null)
			{
				existingCartItem.Quantity++;
			}
			else
			{
				cartItems.Add(new CartItem
				{
					Device = deviceToAdd,
					Quantity = 1
				});
			}

			HttpContext.Session.Set("Cart", cartItems);

			TempData["CartMessage"] = $"{deviceToAdd.Name} добавлен в корзину";

			return RedirectToAction("ViewCart");
		}

		[HttpGet]
		public IActionResult ViewCart()
		{

			var cartItems = HttpContext.Session.Get<List<CartItem>>("Cart") ?? new List<CartItem>();

			var cartViewModel = new Cart
			{
				CartItems = cartItems,
				TotalPrice = cartItems.Sum(item => item.Device.Price * item.Quantity)
			};

			ViewBag.CartMessage = TempData["CartMessage"];

			return View(cartViewModel);
		}

		public IActionResult RemoveItem(int id)
		{
			var bicycleToAdd = db.Device.Find(id);

			var cartItems = HttpContext.Session.Get<List<CartItem>>("Cart") ?? new List<CartItem>();

			var itemToRemove = cartItems.FirstOrDefault(item => item.Device.Id == id);

			if (itemToRemove != null)
			{
				if (itemToRemove.Quantity > 1)
				{
					itemToRemove.Quantity--;
				}
				else
				{
					TempData["CartMessage"] = $"{itemToRemove.Device.Name} удалён";
					cartItems.Remove(itemToRemove);
				}
			}

			HttpContext.Session.Set("Cart", cartItems);


			return RedirectToAction("ViewCart");
		}

	}
}
