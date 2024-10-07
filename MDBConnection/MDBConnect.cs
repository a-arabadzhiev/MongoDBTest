using MongoDB.Bson;
using MongoDB.Driver;

namespace MDBConnection 
{
    public class MDBConn(string? CollectionName, string? data)
    {
        public static string? MDBConnect(string? CollectionName, string? data)
        {
            string? collection = CollectionName;
            string? ParseData = data;

            string? client = "mongodb+srv://aarabadzhiev:#Zabrav1h@cluster0.urc9udb.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
            string? database = "C#Test";

            var MDBclient = new MongoClient(client);
            var MDBdatabase = MDBclient.GetDatabase(database);
            var MDBcollection = MDBdatabase.GetCollection<BsonDocument>(collection).ToString();

            return MDBcollection;
        }
    }
}


