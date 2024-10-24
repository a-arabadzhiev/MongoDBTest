
using ATConnection;
using MDBInsertDocument;
using MDBFindData;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ATTaxonomyVehicleModels
{
    public class GetVehicleModels
    {
        //public class GetVehicleMake
        //{
        //    [BsonElement("makeId"), BsonRepresentation(BsonType.String)]
        //    public string? makeId { get; set; }
        //}

        //public class SetVehicleMake
        //{
        //    public List<Makeid>? makeId { get; set; }
        //}

        //public class Makeid
        //{
        //    public string? makeId { get; set; }
        //}

        //public class VehicleModels
        //{
        //    public List<Model>? models { get; set; }
        //}

        //public class Model
        //{
        //    public string? modelId { get; set; }
        //    public string? name { get; set; }
        //}

        public static async Task Main()
        {
            string? advertiserid = "66945";

            string? makeid = MDBGetData.Find("VehicleMakes", "{ _id : 0 }", null).ToString();

            Console.WriteLine(makeid); 
            Console.ReadLine();

            string? webext = "models?makeId=" + makeid + "&advertiserId=" + advertiserid;

            string? cookie = "__cf_bm=B6mel2RAr2Y8bJ_YC12yGM72Fz992ZOgK4NdAQIY3qQ-1718109215-1.0.1.1-UBKCntQDCf.gtz4TRb93MxGrFR.aGSkdL8P4mtAD16PxCY1ZzAzjuMOEV3gmMVnclxTq_BvbH7gTIH7Bz6k2BA";

            //string? collection = "VehicleModels";

            string? vehicleMake = await ATConnect.Connect(webext, cookie);

            //var document = BsonDocument.Parse(vehicleMake);

            MDBInsert.InsertOne("VehicleModels", BsonDocument.Parse(vehicleMake));
        }

        //public static async Task Main()
        //{

        //    //foreach (var makeId in data.makeId)
        //    //{
        //        ////Get Auto Trader Vehicle Models
        //        //var advertiserId = "66945";
        //        //var requestUrl = "https://api-sandbox.autotrader.co.uk/taxonomy/models?makeId=" + makeId.makeId + "&advertiserId=" + advertiserId;
        //        //var client = new HttpClient();
        //        //var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
        //        //request.Headers.Add("Authorization", "Bearer " + accesstoken.access_token);
        //        //request.Headers.Add("cpntent-type", "application/json");
        //        //request.Headers.Add("Cookie", "__cf_bm=B6mel2RAr2Y8bJ_YC12yGM72Fz992ZOgK4NdAQIY3qQ-1718109215-1.0.1.1-UBKCntQDCf.gtz4TRb93MxGrFR.aGSkdL8P4mtAD16PxCY1ZzAzjuMOEV3gmMVnclxTq_BvbH7gTIH7Bz6k2BA");
        //        //var response = await client.SendAsync(request);
        //        //response.EnsureSuccessStatusCode();

        //        //string vehicleModel = await response.Content.ReadAsStringAsync();

        //        //VehicleModels? vehmodel = JsonSerializer.Deserialize<VehicleModels>(
        //        //    json: vehicleModel,
        //        //    options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        //            MDBcollection.InsertOne(document);
        //        }
            //}
        //}
    }
}