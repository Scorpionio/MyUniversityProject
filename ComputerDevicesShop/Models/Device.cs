using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerDevicesShop.Models
{
    [Table("Устройства")]
    public class Device
    {
        [Column("Идентификатор_устройства")]
        public int DeviceId { get; set; }
        [Column("Идентификатор_категории")]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(40)]
        [Column("Название")]
        public string Name { get; set; }
        [Required]
        [Column("Цена")]
        public double Price { get; set; }
        [Required]
        [MaxLength(200)]
        [Column("Описание")]
        public string Description { get; set; }
        [Column("Изображение")]
        public string? Image { get; set; }
        [Column("Рейтинг_товара")]
        public double? Rate { get; set; }
        public Category Category { get; set; }
        public Stock Stock { get; set; }
        public List<Rate> Rates { get; set; }
    }
}
