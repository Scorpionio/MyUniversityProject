using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerDevicesShop.Models
{
    [Table("Детали_Корзины")]
    public class CartDetail
    {
        [Column("Идентификатор_деталей_корзины")]
        public int CartDetailId { get; set; }
        [Required]
        [Column("Идентификатор_корзины")]
        public int CartId { get; set; }
        [Required]
        [Column("Идентификатор_устройства")]
        public int DeviceId { get; set; }
        [Required]
        [Column("Количество")]
        [Range(1, 10)]
        public int Quantity { get; set; }
        [Required]
        [Column("Цена_товара")]
        public double UnitPrice { get; set; }
        public Device Device { get; set; }
        public Cart Cart { get; set; }
    }
}
