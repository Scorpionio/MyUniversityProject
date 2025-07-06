using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerDevicesShop.Models
{
    [Table("Роли")]
    public class Role
    {
        [Column("Идентификатор_роли")]
        public int RoleId { get; set; }
        [Required]
        [Column("Название")]
        [MaxLength(40)]
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
