using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerDevicesShop.Models
{
    [Table("Категория")]
    public class Category
    {
        [Column("Идентификатор_категории")]
        public int CategoryId { get; set; }
        [Required]
        [Column("Название")]
        [MaxLength(30)]
        public string Name { get; set; }
        [Column("Идентификатор_устройства")]
        public List<Device> Devices { get; set; }
    }
}
