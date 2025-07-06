using Microsoft.EntityFrameworkCore;
using ComputerDevicesShop.Data;
using ComputerDevicesShop.Models;
using Microsoft.AspNetCore.Mvc;
using ComputerDevicesShop.Models.DTOs;


namespace ComputerDevicesShop.Repositories
{

    public class CartRepository : ICartRepository
    {
        
        public const string CookieName = "UserAuth";
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _db = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> AddItem(int deviceId, int quantity)
        {
            int userId = GetUserId();
            //добавляем устройство в корзину
            try
            {
                if (!Convert.ToBoolean(userId)) {
                    throw new UnauthorizedAccessException("userNotLogin");
                }
                var cart = await GetCart(userId);
                // мы ищем существует ли уже в CartDetails наш товар, если да то +1, иначе добавляем 
                var cartItem = _db.CartDetails
                                  .FirstOrDefault(a => a.CartId == cart.CartId && a.DeviceId == deviceId);
                if (cartItem is not null)
                {
                    cartItem.Quantity += 1;
                }
                else {
                    var device = _db.Devices.FirstOrDefault(d => d.DeviceId == deviceId);
                    cartItem = new CartDetail
                    {
                        CartId = cart.CartId,
                        DeviceId = deviceId,
                        Quantity = quantity,
                        UnitPrice = device.Price
                    };
                    _db.CartDetails.Add(cartItem);
                }
                _db.SaveChanges();
            }
            catch (Exception ex) { 
            }
            //возвращяем список
            var cartItemList = await GetCartItemCount(userId);
            return cartItemList;
        }

        public async Task<int> DeleteItem(int deviceId, int quantity)
        {
            int userId = GetUserId();
            //удаляем устройство из корзины
            try
            {
                if (!Convert.ToBoolean(userId))
                {
                    throw new UnauthorizedAccessException("userNotLogin");
                }
                var cart = _db.Carts.FirstOrDefault(c => c.UserId == userId);
                var device = _db.Devices.FirstOrDefault(d => d.DeviceId == deviceId);
                // мы ищем существует ли уже в CartDetails наш товар, если да то +1, иначе удаляем 
                var cartItem = _db.CartDetails
                                  .FirstOrDefault(a => a.CartId == cart.CartId && a.DeviceId == deviceId);
                if (cartItem.Quantity == 1)
                {
                    _db.CartDetails.Remove(cartItem);
                }
                else
                {
                    cartItem.Quantity -= 1;
                }
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
            }
            //возвращяем список
            var cartItemList = await GetCartItemCount(userId);
            return cartItemList;
        }

        public async Task<Cart> GetUserCart()
        {
            var userId = GetUserId();
            User user = _db.Users.FirstOrDefault(u => u.UserId == userId);
            var shoppingCart = await _db.Carts
                                    .Include(a => a.CartDetails)
                                    .ThenInclude(a => a.Device)
                                    .ThenInclude(a => a.Stock)
                                    .Include(a => a.CartDetails)
                                    .ThenInclude(a => a.Device)
                                    .ThenInclude(a => a.Category)
                                    .Where(a => a.UserId == userId).FirstOrDefaultAsync();
            return shoppingCart;

        }

        public async Task<Cart> GetCart(int userId) {
            var userCart = await _db.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
            return userCart;
        }

        public async Task<int> GetCartItemCount(int userId = 0)
        {
            if (!Convert.ToBoolean(userId))
            {
                userId = GetUserId();
            }
            var data = await (from cart in _db.Carts
                              join cartDetail in _db.CartDetails
                              on cart.CartId equals cartDetail.CartId
                              where cart.UserId == userId
                              select new { cartDetail.CartDetailId }
                        ).ToListAsync();
            return data.Count;
        }

        public async Task<int?> CreateOrder(CheckoutModel model) {
            try
            {
                int userId = GetUserId();
                var userCart = await GetCart(userId);
                var cartDetails = _db.CartDetails.Where(c => c.CartId == userCart.CartId);
                var pendingRecord = _db.OrderStatuses.FirstOrDefault(s => s.StatusName == "Отправлено");
                var order = new Order
                {
                    UserId = userId,
                    OrderStatusId = pendingRecord.OrderStatusId,
                    CreateDate = DateTime.UtcNow,
                    Name = model.Name,
                    Email = model.Email,
                    MobileNumber = model.MobileNumber,
                    Address = model.Address,
                    IsPaid = false,
                };
                _db.Orders.Add(order);
                _db.SaveChanges();
                foreach (var item in cartDetails)
                {
                    var orderDetail = new OrderDetail
                    {
                        DeviceId = item.DeviceId,
                        OrderId = order.OrderId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    };
                    _db.OrderDetails.Add(orderDetail);

                    var stock = await _db.Stocks.FirstOrDefaultAsync(a => a.DeviceId == item.DeviceId);

                    if (item.Quantity > stock.Count)
                    {
                        throw new InvalidOperationException($"Only {stock.Count} items(s) are available in the stock");
                    }
                    stock.Count -= item.Quantity;
                }

                _db.CartDetails.RemoveRange(cartDetails);
                _db.SaveChanges();
                return order.OrderId;
            }
            catch (Exception ex) {
                return null;
            }
        }

        public int GetUserId() {
            var context = _httpContextAccessor.HttpContext;
            if (context != null && context.Request.Cookies.TryGetValue("UserAuth", out var CookieName))
            {
                User user = _db.Users.FirstOrDefault(u => u.Name == CookieName);
                return user.UserId;
            }
            return 0;
        }
    }
}
