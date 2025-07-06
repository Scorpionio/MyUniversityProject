using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerDevicesShop.Models
{
    [Table("Корзина")]
    public class Cart
    {
        [Column("Идентификатор_корзины")]
        public int CartId { get; set; }
        [Required]
        [Column("Идентификатор_пользователя")]
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<CartDetail> CartDetails { get; set; }
    }
}
