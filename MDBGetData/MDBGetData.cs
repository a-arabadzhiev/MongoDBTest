using MongoDB.Bson;
using MongoDB.Driver;

namespace MDBFindData
{
    public class MDBGetData(string? CollectionName, string? Filter, string? Project)
    {
        public static void Main() { }
        public static List<BsonDocument>? Find(string? CollectionName, string? Filter, string? Project)
        {
            string? client = "mongodb+srv://aarabadzhiev:#Zabrav1h@cluster0.urc9udb.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
            string? database = "C#Test";

            var MDBclient = new MongoClient(client);
            var MDBdatabase = MDBclient.GetDatabase(database);
            var MDBcollection = MDBdatabase.GetCollection<BsonDocument>(CollectionName);

            var FindData = MDBcollection.Find(Filter)
                                        .Project(Project)
                                        .ToList();

            return FindData;
        }
    }
}
