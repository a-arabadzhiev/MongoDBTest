
namespace ATTaxonomyVehicleTypes
{
    internal class GetResults
    {
        public static void Main()
        {
            //string at = new GetAccessToken().ToString();
            string vt = new GetVehicleTypes().ToString();

            Console.WriteLine(vt); //, at);
            Console.ReadKey();
        }
    }
}
