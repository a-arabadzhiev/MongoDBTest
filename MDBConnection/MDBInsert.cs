using MongoDB.Bson;
using MongoDB.Driver;

namespace MDBInsertDocument
{
    public class MDBInsert(string? CollectionName, BsonDocument? Document)
    {
        public static void Main() { } 
        public static void InsertOne(string? CollectionName, BsonDocument? Document)
        {
            var MDBclient = new MongoClient(GlobalVariables.Variables.MDBCred.client);
            var MDBdatabase = MDBclient.GetDatabase(GlobalVariables.Variables.MDBCred.database);
            var MDBcollection = MDBdatabase.GetCollection<BsonDocument>(CollectionName);

            MDBcollection.InsertOne(Document);
        }
    }
}