using Newtonsoft.Json;
using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace ATTaxonomyVehiclesTypes
{
    public class JSON
    {
        public Vehicletype[]? vehicleTypes { get; set; }
    }

    public class Vehicletype
    {
        public string? name { get; set; }
    }

    public class BSON
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [BsonElement("access_token"), BsonRepresentation(BsonType.String)]
        public string acces_token { get; set; }

        [BsonElement("expires"), BsonRepresentation(BsonType.DateTime)]
        public DateTime expires { get; set; }

    }

    public class VehicleTypesArr
    {
        public static async Task Main()
        {
            //Connect to MongoDB

            const string connectionUri = "mongodb+srv://aarabadzhiev:#Zabrav1h@cluster0.urc9udb.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";

            var settings = MongoClientSettings.FromConnectionString(connectionUri);

            // Set the ServerApi field of the settings object to set the version of the Stable API on the client
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            // Create a new client and connect to the server
            var MongoDBClient = new MongoClient(settings);

            var database = MongoDBClient.GetDatabase("C#Test");
            var MongoDBcollection = database.GetCollection<BsonDocument>("AccessToken");

            //var BsonDocument = MongoDBcollection.Find("{}").Sort("{expires: -1}").Limit(1).FirstOrDefault();
            //Console.Write(MongoDBcollection.Find("{}").Sort("{expires: -1}").Limit(1).FirstOrDefault().ToString());
            string Document = MongoDBcollection.Find("{}").Sort("{_id: -1}").Limit(1).FirstOrDefault().ToString();

            Console.Write(Document);
            Console.Read();

            string accesstoken = Document.Substring(66, 133);
            //string expires = Document.Substring(215, 28);
            Console.Write(accesstoken);
            Console.Read();


            //DateTime DateExpires;
            //DateTime DateExpires = DateTime.ParseExact(expires, "ddd MMM d hh:mm:ss UTC yyyy", CultureInfo.InvariantCulture);

            //if (DateExpires > DateTime.Now)
            //{

            var advertiserId = "66945";
            var requestUrl = "https://api-sandbox.autotrader.co.uk/taxonomy/vehicleTypes?advertiserId=" + advertiserId;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.Headers.Add("Authorization", "Bearer " + accesstoken);
            request.Headers.Add("cpntent-type", "application/json");
            request.Headers.Add("Cookie", "__cf_bm=B6mel2RAr2Y8bJ_YC12yGM72Fz992ZOgK4NdAQIY3qQ-1718109215-1.0.1.1-UBKCntQDCf.gtz4TRb93MxGrFR.aGSkdL8P4mtAD16PxCY1ZzAzjuMOEV3gmMVnclxTq_BvbH7gTIH7Bz6k2BA");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            //Console.WriteLine(await response.Content.ReadAsStringAsync());
            //}
            //else
            //{
            //    Console.WriteLine("Token expired"); Console.ReadLine(); return;
            //}

            //Get values from Json
            //string jsonString = await response.Content.ReadAsStringAsync();

            //string jsonString = """{ "vehicleTypes": [{ "name": "Bike" }] }""";

            //Console.WriteLine(jsonString);
            //Console.ReadKey();

            //JSON data = JsonConvert.DeserializeObject<JSON>(jsonString);
            string jsonString = "{vehicleTypes: [{ name: 'Bike' }] }";
            var data = JsonConvert.DeserializeObject<JSON>(jsonString);

            //{
            //    foreach (var name in VehicleTypesArr.vehicleTypes)
            //        Console.WriteLine("Vehicle Type: " + name);
            //}


            Console.WriteLine(data);
            Console.ReadKey();

            //MongoDBcollection = database.GetCollection<BsonDocument>("VehicleTypes");

            ////Isert Token values
            //var document = new BsonDocument
            //{
            //    { "name", vehicletypes.name }
            //};

            ////MongoDBcollection.InsertOne(document);

            ////Check Result
            //var firstDocument = MongoDBcollection.Find(document).FirstOrDefault();
            //Console.WriteLine(firstDocument.ToString());
        }
    }
}
