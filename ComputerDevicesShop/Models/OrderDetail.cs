 using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ComputerDevicesShop.Models
{
    [Table("Детали_Заказа")]
    public class OrderDetail
    {
        [Column("Идентификатор_деталей_заказа")]
        public int OrderDetailId { get; set; }
        [Required]
        [Column("Идентификатор_заказа")]
        public int OrderId { get; set; }
        [Required]
        [Column("Идентификатор_устройства")]
        public int DeviceId { get; set; }
        [Required]
        [Column("Количество")]
        public int Quantity { get; set; }
        [Required]
        [Column("Цена_товара")]
        public double UnitPrice { get; set; }
        public Order Order { get; set; }
        public Device Device { get; set; }
    }
}
