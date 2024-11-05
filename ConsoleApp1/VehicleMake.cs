using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTaxonomyVehicleMakes
{
    public class VehicleMake
    {
        public List<Make>? makes { get; set; }
    }
    public class Make
    {
        public string? makeId { get; set; }
        public string? name { get; set; }
    }
}
