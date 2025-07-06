using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerDevicesShop.Models
{
    [Table("Рейтинг")]
    public class Rate
    {
        [Column("Идентификатор_пользователя")]
        public int UserId { get; set; }
        [Column("Идентификатор_устройства")]
        public int DeviceId { get; set; }
        [Column("Оценка")]
        [Range(1, 5)]
        public double Rateing { get; set; }
        public User User { get; set; }
        public Device Device { get; set; }
    }
}
