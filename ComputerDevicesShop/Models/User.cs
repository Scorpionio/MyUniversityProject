using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerDevicesShop.Models
{
    [Table("Пользователи")]
    public class User
    {
        [Column("Идентификатор_пользовалетеля")]
        public int UserId { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("Имя_пользовалетеля")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        [Column("Почта_пользовалетеля")]
        public string Email { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        [Column("Пароль")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d).+$")]
        public string Password { get; set; }
        [Column("Роль")]
        public int RoleId { get; set; }
        public List<Rate> Rates { get; set; }
        public Role Role { get; set; }
        public Cart Cart { get; set; }
    }
}
