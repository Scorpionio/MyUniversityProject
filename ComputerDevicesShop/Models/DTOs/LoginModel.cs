using System.ComponentModel.DataAnnotations;

namespace ComputerDevicesShop.Models.DTOs
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Неправельная форма почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
