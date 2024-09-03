
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json;

namespace ATTaxonomyVehicleTypes
{
    public class GetVehicleTypes
    {
        public class AccessToken
        {
            public string? access_token { get; set; }
            public string? expires { get; set; }
        }

        public class GetVehicleType
        {
            public List<Vehicletype>? vehicleTypes { get; set; }
        }

        public class Vehicletype
        {
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

            //Get Auto Trader Vehicle Types
            var advertiserId = "66945";
            var requestUrl = "https://api-sandbox.autotrader.co.uk/taxonomy/vehicleTypes?advertiserId=" + advertiserId;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.Headers.Add("Authorization", "Bearer " + accesstoken.access_token);
            request.Headers.Add("cpntent-type", "application/json");
            request.Headers.Add("Cookie", "__cf_bm=B6mel2RAr2Y8bJ_YC12yGM72Fz992ZOgK4NdAQIY3qQ-1718109215-1.0.1.1-UBKCntQDCf.gtz4TRb93MxGrFR.aGSkdL8P4mtAD16PxCY1ZzAzjuMOEV3gmMVnclxTq_BvbH7gTIH7Bz6k2BA");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string vt = await response.Content.ReadAsStringAsync();

            GetVehicleType? data = JsonSerializer.Deserialize<GetVehicleType>(
                json: vt, 
                options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true} );

            //Insert Vehicle Types in MongoDB
            var MDBclient = new MongoClient("mongodb+srv://aarabadzhiev:#Zabrav1h@cluster0.urc9udb.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
            var MDBdatabase = MDBclient.GetDatabase("C#Test");
            var MBDcollection = MDBdatabase.GetCollection<BsonDocument>("VehicleTypes");

            foreach (var vehicleType in data.vehicleTypes)
            {

                var document = new BsonDocument
                {
                    {"name", vehicleType.name}
                };

                MBDcollection.InsertOne(document);

            }
        }
    }
}