using ATToken;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ATTaxonomyVehicleTypes
{
    public class GetVehicleTypes
    {
        public static async Task<string?> VehicleType()
        {
            var token = new GetToken();

            var advertiserId = "66945";

            var requestUrl = "https://api-sandbox.autotrader.co.uk/taxonomy/vehicleTypes?advertiserId=" + advertiserId;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.Headers.Add("Authorization", "Bearer " + token.access_token);
            request.Headers.Add("cpntent-type", "application/json");
            request.Headers.Add("Cookie", "__cf_bm=B6mel2RAr2Y8bJ_YC12yGM72Fz992ZOgK4NdAQIY3qQ-1718109215-1.0.1.1-UBKCntQDCf.gtz4TRb93MxGrFR.aGSkdL8P4mtAD16PxCY1ZzAzjuMOEV3gmMVnclxTq_BvbH7gTIH7Bz6k2BA");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string? vehtyp = await response.Content.ReadAsStringAsync();

            return vehtyp;
        }
        public static async Task Main()
        {
            string? vehtyp = await VehicleType();

            //Insert Vehicle Types in MongoDB
            var MDBclient = new MongoClient("mongodb+srv://aarabadzhiev:#Zabrav1h@cluster0.urc9udb.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
            var MDBdatabase = MDBclient.GetDatabase("C#Test");
            var MBDcollection = MDBdatabase.GetCollection<BsonDocument>("VehicleTypes");

            var document = BsonDocument.Parse(vehtyp);

            MBDcollection.InsertOne(document);
        }
    }
}