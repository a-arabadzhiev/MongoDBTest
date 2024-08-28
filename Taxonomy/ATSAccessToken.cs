
using System.Globalization;
using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ATSandboxToken
{
    public class AccessToken
    {
        public string? access_token { get; set; }
        public string? expires { get; set; }
    }

    public class Program
    {
        public static async Task Main()
        {

            var key = "eDynamix-StockMGT-Parkway-SB-01-06-23";
            var secret = "ZBNFVVGyTf3Ne61edbP5IY7y6L7XTB8W";

            //Get Auto Trader Sandbox token
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api-sandbox.autotrader.co.uk/authenticate");
            request.Headers.Add("Cookie", "__cf_bm=ib4fWOcQI.p0UonnDcf.YP7U6plrQs2VcxbjSBmUdT4-1718029262-1.0.1.1-SKsHzyviga_1FAwZjDxtUNz3qhex6_tCZh06hQrhqkbtdCSuaaz7PfpSVk34TAQapXxSeKMuWFrAgxcQ7GeQsA");
            var collection = new List<KeyValuePair<string, string>>();
                collection.Add(new("key", key));
                collection.Add(new("secret", secret));
            var content = new FormUrlEncodedContent(collection);
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string AccessTokenRes = await response.Content.ReadAsStringAsync();

            //Get values from Json
            string jsonString = AccessTokenRes;

            AccessToken? accesstoken =
                JsonSerializer.Deserialize<AccessToken>(jsonString);

            DateTime DateExpires;
            DateTime.TryParseExact(accesstoken.expires, "ddd MMM d hh:mm:ss UTC yyyy", null, DateTimeStyles.None, out DateExpires);

            //string access_token = accesstoken.access_token;

            //Connect to MongoDB
            const string connectionUri = "mongodb+srv://aarabadzhiev:#Zabrav1h@cluster0.urc9udb.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";

            var settings = MongoClientSettings.FromConnectionString(connectionUri);

            // Set the ServerApi field of the settings object to set the version of the Stable API on the client
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            // Create a new client and connect to the server
            var MongoDBClient = new MongoClient(settings);

            var database = MongoDBClient.GetDatabase("C#Test");
            var MongoDBcollection = database.GetCollection<BsonDocument>("AccessToken");

            //Isert Token values
            var document = new BsonDocument
            {
                { "access_token", accesstoken.access_token },
                { "expires", DateExpires}
            };

            MongoDBcollection.InsertOne(document);

            //Check Result
            var firstDocument = MongoDBcollection.Find(document).FirstOrDefault();
            Console.WriteLine(firstDocument.ToString());
        }
    }
}