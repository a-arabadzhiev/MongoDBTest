using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTaxonomyVehicleDerivatives
{
    public class VehicleDerivative
    {
        public List<Derivative>? derivatives { get; set; }
    }

    public class Derivative
    {
        public string? derivativeId { get; set; }
        public string? name { get; set; }
        public DateTime? introduced { get; set; }
        public DateTime? discontinued { get; set; }
    }
}
