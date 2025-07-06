using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ComputerDevicesShop.Models.DTOs
{
    public class AddDeviceDTO
    {
        [ValidateNever]
        [BindNever]
        public IEnumerable<Category> Categories { get; set; }

        public AddDeviceModel AddDeviceModel { get; set; }
        public int CategoryId { get; set; }
    }
}
