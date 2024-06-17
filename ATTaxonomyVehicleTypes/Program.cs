
using MongoDB.Bson;
using MongoDB.Driver;

namespace ATTaxonomyVehiclesTypes
{
    public class Program
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
            string Document = MongoDBcollection.Find("{}").Sort("{expires: 1}").Limit(1).FirstOrDefault().ToString();

            string accesstoken = Document.Substring(66, 133);
            //DateTime expires = Document.Substring(223, 20);
            //Console.WriteLine(accesstoken);
            //Console.ReadLine();
            //return;

            //if (expires > DateTime.Now)
            //{

                var advertiserId = "66945";
                var requestUrl = "https://api-sandbox.autotrader.co.uk/taxonomy/vehicleTypes?advertiserId=" + advertiserId;
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                //var Bearer = "Bearer " + accesstoken;
                request.Headers.Add("Authorization", "Bearer " + accesstoken);
                request.Headers.Add("cpntent-type", "application/json");
                request.Headers.Add("Cookie", "__cf_bm=B6mel2RAr2Y8bJ_YC12yGM72Fz992ZOgK4NdAQIY3qQ-1718109215-1.0.1.1-UBKCntQDCf.gtz4TRb93MxGrFR.aGSkdL8P4mtAD16PxCY1ZzAzjuMOEV3gmMVnclxTq_BvbH7gTIH7Bz6k2BA");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            //}
            //else
            //{
            //    Console.WriteLine("Token expired"); Console.ReadLine(); return;
            //}
        }
    }
}
