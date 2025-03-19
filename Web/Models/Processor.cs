
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Processor : Device
    {
        
        public int Cores { get; set; }
        public int Threads { get; set; }
    }
}
