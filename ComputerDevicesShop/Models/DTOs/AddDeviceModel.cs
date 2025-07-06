using System.ComponentModel.DataAnnotations;

namespace ComputerDevicesShop.Models.DTOs
{
    public class AddDeviceModel
    {
        [Required(ErrorMessage = "Не указано название")]
        [MaxLength(40, ErrorMessage = "Название должно быть до 40 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указана цена")]
        [Range(1, 10000, ErrorMessage = "Цена должна быть от 1 до 10000 руб")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Не указано описание")]
        [MaxLength(200, ErrorMessage = "Описание должно быть до 200 символов")]
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
    }
}
