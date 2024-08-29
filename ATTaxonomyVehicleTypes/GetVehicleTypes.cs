
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System.Text.Json;

namespace ATTaxonomyVehicleTypes
{
    public class GetVehicleTypes
    {

        public class JSON
        {
            public Vehicletype[]? vehicleTypes { get; set; }
        }

        public class Vehicletype
        {
            public string? name { get; set; }
        }

        public static async Task Main()
        {

            var MDBclient = new MongoClient("mongodb+srv://aarabadzhiev:#Zabrav1h@cluster0.urc9udb.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
            var database = MDBclient.GetDatabase("C#Test");
            var collection = database.GetCollection<BsonDocument>("AccessToken");

            var at = collection.Find("{}").Sort("{_id: -1}").Limit(1).FirstOrDefault().ToString().Substring(66, 133 );

            //Console.WriteLine(at);
            //Console.ReadKey();

            var advertiserId = "66945";
            var requestUrl = "https://api-sandbox.autotrader.co.uk/taxonomy/vehicleTypes?advertiserId=" + advertiserId;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.Headers.Add("Authorization", "Bearer " + at);
            request.Headers.Add("cpntent-type", "application/json");
            request.Headers.Add("Cookie", "__cf_bm=B6mel2RAr2Y8bJ_YC12yGM72Fz992ZOgK4NdAQIY3qQ-1718109215-1.0.1.1-UBKCntQDCf.gtz4TRb93MxGrFR.aGSkdL8P4mtAD16PxCY1ZzAzjuMOEV3gmMVnclxTq_BvbH7gTIH7Bz6k2BA");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string vt = await response.Content.ReadAsStringAsync();

            //Console.WriteLine(vt);
            //Console.ReadKey();

            JSON? data = JsonSerializer.Deserialize<JSON>(vt);

            //Console.WriteLine(vt);
            //Console.ReadKey();

            Console.WriteLine(data);
            Console.ReadKey();
        }
    }
}
