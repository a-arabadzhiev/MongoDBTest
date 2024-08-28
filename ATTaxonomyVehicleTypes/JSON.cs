using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTaxonomyVehicleTypes
{
    public class JSON
    {    
        public Vehicletype[]? vehicleTypes { get; set; }
        }

        public class Vehicletype
        {
            public string? name { get; set; }
        }
}
