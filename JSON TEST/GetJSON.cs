//using MongoDB.Bson;
//using MongoDB.Bson.IO;
//using MongoDB.Driver;
using System.Text.Json;

namespace JSON_TEST
{
    public class GetJSON
    {
        public class JSON
        {
            public List<VehicleType>? vehicleTypes { get; set; }
        }

        public class VehicleType
        {
            public string? name { get; set; }
        }

        public static void Main()
        {

            JSON root = new JSON()
            {
                vehicleTypes = new List<VehicleType>(),
            };

            VehicleType vehicletype = new VehicleType()
            {
                name = "CAR",
            };

            Console.WriteLine(root);
            Console.ReadKey();

            //string jsn = "{"vehicleTypes": [{"name": "Bike"}, {"name": "Car"}]}"

            //JSON? res = JsonSerializer.Deserialize<JSON>(jsn);

            //Console.WriteLine(res);
            //Console.ReadKey();
        }
    }
}

