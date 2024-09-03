
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Security.Cryptography;
using System.Text.Json;
using System.Xml.Linq;
using static ATTaxonomyVehicleModels.GetVehicleModels;

namespace ATTaxonomyVehicleModels
{
    public class GetVehicleModels
    {
        public class AccessToken
        {
            public string? access_token { get; set; }
            public string? expires { get; set; }
        }

        public class GetVehicleMake
        {
            [BsonElement("makeId"), BsonRepresentation(BsonType.String)]
            public string? makeId { get; set; }
        }

        public class SetVehicleMake
        {
            public List<Makeid>? makeId { get; set; }
        }

        public class Makeid
        {
            public string? makeId { get; set; }
        }

        public class VehicleModels
        {
            public List<Model>? model { get; set; }
        }

        public class Model
        {
            public string? modelId { get; set; }
            public string? name { get; set; }
        }





        public static async Task Main()
        {
            var key = "eDynamix-StockMGT-Parkway-SB-01-06-23";
            var secret = "ZBNFVVGyTf3Ne61edbP5IY7y6L7XTB8W";

            //Get Auto Trader Sandbox token
            var ATclient = new HttpClient();
            var ATrequest = new HttpRequestMessage(HttpMethod.Post, "https://api-sandbox.autotrader.co.uk/authenticate");
            ATrequest.Headers.Add("Cookie", "__cf_bm=ib4fWOcQI.p0UonnDcf.YP7U6plrQs2VcxbjSBmUdT4-1718029262-1.0.1.1-SKsHzyviga_1FAwZjDxtUNz3qhex6_tCZh06hQrhqkbtdCSuaaz7PfpSVk34TAQapXxSeKMuWFrAgxcQ7GeQsA");
            var collection = new List<KeyValuePair<string, string>>();
            collection.Add(new("key", key));
            collection.Add(new("secret", secret));
            var content = new FormUrlEncodedContent(collection);
            ATrequest.Content = content;
            var ATresponse = await ATclient.SendAsync(ATrequest);
            ATresponse.EnsureSuccessStatusCode();

            string AccessTokenRes = await ATresponse.Content.ReadAsStringAsync();
            AccessToken? accesstoken = JsonSerializer.Deserialize<AccessToken>(AccessTokenRes);

            //Get VehicleMake
            var MDBclient = new MongoClient("mongodb+srv://aarabadzhiev:#Zabrav1h@cluster0.urc9udb.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
            var MDBdatabase = MDBclient.GetDatabase("C#Test");
            var MDBcollection = MDBdatabase.GetCollection<BsonDocument>("VehicleMakes");

            var vehicleMake = MDBcollection
                                           .Find("{}")
                                           .Sort("{name : 1}")
                                           .Project("{ _id : 0, name : 0 }")
                                           .ToList();

            //foreach (var makeId in vehicleMake)
            //{

            string? vm = vehicleMake.Select(v => BsonSerializer.Deserialize<GetVehicleMake>(v)).ToJson();

            //vm = "{\"makeId\":" + vm + "}";

            vm = "{\"makeId\":[{\"makeId\": \"d00ef9d875e8af95d2a090f92732ebd6\"},{\"makeId\": \"32e47866f467460ba397a85c0df37f2d\"}]}";

            //Console.WriteLine(vm);
            //Console.ReadLine();

            SetVehicleMake? data = JsonSerializer.Deserialize<SetVehicleMake>(
                json: vm
                //, options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );

            //Console.WriteLine(data.makeId);
            //Console.ReadLine();

            foreach (var makeId in data.makeId)
            {
                //string sid = makeId.ToString();

                Makeid? id = JsonSerializer.Deserialize<Makeid>(makeId.ToString());

                Console.WriteLine(id);
                Console.ReadLine();
            }
            //Console.WriteLine(vehicleMake);
            //Console.ReadLine();

            //string? vm = vehicleMake.Select(v => BsonSerializer.Deserialize<GetVehicleMake>(v)).ToJson();

            ////vt = vt.Replace("[", "").Replace("]", "");

            //Console.WriteLine(vm);
            //Console.ReadLine();



            /*
            SetVehicleType? data = JsonSerializer.Deserialize<SetVehicleType>(vt);

            //Get Auto Trader Vehicle Types
            var advertiserId = "66945"; //models?makeId=&advertiserId=1234
            var requestUrl = "https://api-sandbox.autotrader.co.uk/taxonomy/models?makeId=" + data.makeId + "&advertiserId=" + advertiserId;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.Headers.Add("Authorization", "Bearer " + accesstoken.access_token);
            request.Headers.Add("cpntent-type", "application/json");
            request.Headers.Add("Cookie", "__cf_bm=B6mel2RAr2Y8bJ_YC12yGM72Fz992ZOgK4NdAQIY3qQ-1718109215-1.0.1.1-UBKCntQDCf.gtz4TRb93MxGrFR.aGSkdL8P4mtAD16PxCY1ZzAzjuMOEV3gmMVnclxTq_BvbH7gTIH7Bz6k2BA");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string vehicleMake = await response.Content.ReadAsStringAsync();

            VehicleMakes? vm = JsonSerializer.Deserialize<VehicleMakes>(
                json: vehicleMake,
                options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            MDBcollection = null;
            MDBcollection = MDBdatabase.GetCollection<BsonDocument>("VehicleMakes");

            foreach (var Make in vm.makes)
            {

                var document = new BsonDocument
                {
                    {"makeId", Make.makeId},
                    {"name", Make.name}
                };

                MDBcollection.InsertOne(document);

            //*/

            //}
        }
    }
}