using ATTaxonomyVehicleTypes;

namespace PipeLine
{
    public class PipeLine
    {
        public static void Main()
        {
            GetVehicleTypes.GetVehicleType(GlobalVariables.Variables.GetVehicleTypesReq.WebSiteType);
        }
    }
}