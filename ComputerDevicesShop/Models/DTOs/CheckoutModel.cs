using System.ComponentModel.DataAnnotations;

namespace ComputerDevicesShop.Models.DTOs
{
    public class CheckoutModel
    {
        [Required(ErrorMessage = "Обязательно введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Должена быть указана почта")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Не правельный формат почты")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Должен быть указан телефон")]
        [RegularExpression(@"^(?=.*[+]375).{13}$", ErrorMessage = "Не правельный формат телефона")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Должен быть указан адрес")]
        public string Address { get; set; }
    }
}
