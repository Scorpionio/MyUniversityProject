using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerDevicesShop.Models
{
    [Table("Статус_Заказа")]
    public class OrderStatus
    {
        [Column("Идентификатор_статуса_заказа")]
        public int OrderStatusId { get; set; }
        [Required]
        [Column("Идентификатор_заказа")]
        public int StatusId { get; set; }
        [Required, MaxLength(20)]
        [Column("Название")]
        public string? StatusName { get; set; }
    }
}
