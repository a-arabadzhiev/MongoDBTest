using System.Text.Json;

namespace JSON_TEST
{
    public class GetJSON
    {
        //public class JSON
        //{
        //    public List<VehicleType>? vehicleTypes { get; set; }
        //}

        public class VehicleType
        {
            public string? name { get; set; }
        }

        public static void Main()
        {

            string jsn = """{"name": "Car"}""";

             VehicleType? res = JsonSerializer.Deserialize<VehicleType>(jsn);

            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}