using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerDevicesShop.Models
{
    [Table("Склад")]
    public class Stock
    {
        [Column("Идентификатор_склада")]
        public int StockId { get; set; }
        [Column("Идентификатор_устройства")]
        public int DeviceId { get; set; }
        [Column("Количество")]
        [Range(1, 250)]
        public int Count { get; set; }
        public Device Device { get; set; }
    }
}
