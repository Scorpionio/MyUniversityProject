using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerDevicesShop.Models
{
    [Table("Заказ")]
    public class Order
    {
        [Column("Идентификатор_заказа")]
        public int OrderId { get; set; }
        [Column("Идентификатор_пользовалетеля")]
        public int UserId { get; set; }
        [Column("Идентификатор_статуса_заказа")]
        public int OrderStatusId { get; set; }
        [Column("Дата")]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        [Required]
        [MaxLength(30)]
        [Column("Название")]
        public string? Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        [MaxLength(30)]
        [Column("Почта")]
        public string? Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[+]375).{13}$")]
        [Column("Номер_телефона")]
        public string? MobileNumber { get; set; }
        [Required]
        [MaxLength(200)]
        [Column("Адрес")]
        public string? Address { get; set; }
        [Column("Оплата")]
        public bool IsPaid { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public User User { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
    }
}
