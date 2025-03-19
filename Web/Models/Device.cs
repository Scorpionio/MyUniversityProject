using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models
{
    public class Device
    {
        [Key]
        //[DisplayName("Идентификатор")]
        public int Id { get; set; }


        //[DisplayName("Название")]
        public string Name { get; set; }

        //[DisplayName("Стоимость")]
        public decimal Price { get; set; }

        //[DisplayName("Изображение")]
        public string ImgSrc { get; set; }
    }
}
