using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class GraphicCard : Device
    {
        
        public int MemoryCapacity {  get; set; }
    }
}
