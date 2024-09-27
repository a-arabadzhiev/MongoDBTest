
using ATToken;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Text.Json;

namespace ATTaxonomyVehicleMakes
{
    public class GetVehicleMakes
    {
        public class GetVehicleType
        {
            [BsonElement("name"), BsonRepresentation(BsonType.String)]
            public string? name { get; set; }
        }

        public class SetVehicleType
        {
            public string? name { get; set; }
        }


        public class VehicleMakes
        {
            public List<Make>? makes { get; set; }
        }

        public class Make
        {
            public string? makeId { get; set; }
            public string? name { get; set; }
        }


        public static async Task Main()
        {
            //Get VehicleType
            var MDBclient = new MongoClient("mongodb+srv://aarabadzhiev:#Zabrav1h@cluster0.urc9udb.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
            var MDBdatabase = MDBclient.GetDatabase("C#Test");
            var MDBcollection = MDBdatabase.GetCollection<BsonDocument>("VehicleTypes");

            var vehicleType = MDBcollection.Find("{ name: \"Car\" }")
                                           .Project("{ _id : 0 }")
                                           .ToList();

            string? vehtyp = vehicleType.Select(v => BsonSerializer.Deserialize<GetVehicleType>(v)).ToJson();

            vehtyp = vehtyp.Replace("[", "").Replace("]", "");

            SetVehicleType? data = JsonSerializer.Deserialize<SetVehicleType?>(vehtyp);

            var token = new GetToken();

            //Get Auto Trader Vehicle Makes
            var advertiserId = "66945";

            var requestUrl = "https://api-sandbox.autotrader.co.uk/taxonomy/makes?vehicleType=" + data.name + "&advertiserId=" + advertiserId;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.Headers.Add("Authorization", "Bearer " + token.access_token);
            request.Headers.Add("cpntent-type", "application/json");
            request.Headers.Add("Cookie", "__cf_bm=B6mel2RAr2Y8bJ_YC12yGM72Fz992ZOgK4NdAQIY3qQ-1718109215-1.0.1.1-UBKCntQDCf.gtz4TRb93MxGrFR.aGSkdL8P4mtAD16PxCY1ZzAzjuMOEV3gmMVnclxTq_BvbH7gTIH7Bz6k2BA");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string vehicleMake = await response.Content.ReadAsStringAsync();

            //VehicleMakes? vehmke = JsonSerializer.Deserialize<VehicleMakes>(
            //    json: vehicleMake,
            //    options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            MDBcollection = null;
            MDBcollection = MDBdatabase.GetCollection<BsonDocument>("VehicleMakes");

            foreach (var Make in vehicleMake)
            {

                var document = BsonDocument.Parse(vehicleMake);

                MDBcollection.InsertOne(document);

            }
        }
    }
}