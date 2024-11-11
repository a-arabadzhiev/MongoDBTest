using MongoDB.Bson;
using MongoDB.Driver;

namespace MDBInsertDocument
{
    public class MDBInsert(string? CollectionName, BsonDocument? Document)
    {
        public static void Main() { } 
        public static void InsertOne(string? CollectionName, BsonDocument? Document)
        {
            //string? client = "mongodb+srv://aarabadzhiev:#Zabrav1h@cluster0.urc9udb.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
            //string? database = "C#Test";

            var MDBclient = new MongoClient(GlobalVariables.Variables.MDBCred.client);
            var MDBdatabase = MDBclient.GetDatabase(GlobalVariables.Variables.MDBCred.database);
            var MDBcollection = MDBdatabase.GetCollection<BsonDocument>(CollectionName);

            MDBcollection.InsertOne(Document);
        }
    }
}