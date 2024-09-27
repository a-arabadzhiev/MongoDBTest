
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Text.Json;

namespace ATTaxonomyVehicleTechnicalData
{
    public class GetVehicleTechnicalData
    {
        public class AccessToken
        {
            public string? access_token { get; set; }
            public DateTime? expires_at { get; set; }
        }

        public class GetVehicleDerivative
        {
            [BsonElement("derivativeId"), BsonRepresentation(BsonType.String)]
            public string? derivativeId { get; set; }
        }

        public class SetDerivativeId
        {
            public List<Derivativeid>? derivativeId { get; set; }
        }

        public class Derivativeid
        {
            public string? derivativeId { get; set; }
        }

        public static async Task<AccessToken?> Token()
        {
            var key = "eDynamix-StockMGT-Parkway-SB-05-09-24";
            var secret = "JUwLAeG8zzlnJE2jyKizp0mzeEcBD65Q";

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

            return accesstoken;
        }

        public static async Task Main()
        {
            //GetVehicleDerivatives
            var MDBclient = new MongoClient("mongodb+srv://aarabadzhiev:#Zabrav1h@cluster0.urc9udb.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
            var MDBdatabase = MDBclient.GetDatabase("C#Test");
            var MDBcollection = MDBdatabase.GetCollection<BsonDocument>("VehicleDerivatives");

            var vehicleDerivatives = MDBcollection
                                           .Find("{}")
                                           .Sort("{name : 1}")
                                           .Project("{ _id : 0, name : 0, introduced : 0, discontinued : 0 }")
                                           .ToList();

            string? vehder = vehicleDerivatives.Select(v => BsonSerializer.Deserialize<GetVehicleDerivative>(v)).ToJson();

            vehder = "{\"derivativeId\":" + vehder + "}";

            SetDerivativeId? data = JsonSerializer.Deserialize<SetDerivativeId>(
                json: vehder
                , options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );

            var accesstoken = await Token();

            MDBcollection = null;
            MDBcollection = MDBdatabase.GetCollection<BsonDocument>("VehicleTechnicalData");

            foreach (var derivativeId in data.derivativeId)
            {
                //GetVehicleTechnicalData
                var advertiserId = "66945";
                var requestUrl = "https://api-sandbox.autotrader.co.uk/taxonomy/derivatives/" + derivativeId.derivativeId + "?advertiserId=" + advertiserId;
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                request.Headers.Add("Authorization", "Bearer " + accesstoken.access_token);
                request.Headers.Add("cpntent-type", "application/json");
                request.Headers.Add("Cookie", "__cf_bm=B6mel2RAr2Y8bJ_YC12yGM72Fz992ZOgK4NdAQIY3qQ-1718109215-1.0.1.1-UBKCntQDCf.gtz4TRb93MxGrFR.aGSkdL8P4mtAD16PxCY1ZzAzjuMOEV3gmMVnclxTq_BvbH7gTIH7Bz6k2BA");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                string vehicleTechData = await response.Content.ReadAsStringAsync();

                TechnicalData? techdata = JsonSerializer.Deserialize<TechnicalData>(
                    json: vehicleTechData,
                    options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                if (!String.IsNullOrEmpty(techdata.ToString()))
                {
                        var document = BsonDocument.Parse(vehicleTechData);

                        MDBcollection.InsertOne(document);
                }

                if (accesstoken.expires_at <= DateTime.Now.AddMinutes(-58))
                {
                    accesstoken = await Token();

                    Console.WriteLine(accesstoken.expires_at + "\n" + DateTime.Now.AddMinutes(-58) + "\n" + accesstoken.access_token);
                }
            }
        }
    }
}