using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantPalLib.Models
{
     public class Plant
    {
        public string? Name { get; set; }
        public int? PlantId { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }
    }
}
