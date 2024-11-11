using MongoDB.Bson;
using MongoDB.Driver;

namespace MDBFindData
{
    public class MDBGetData(string? CollectionName, string? Filter, string? Project)
    {
        public static void Main() { }
        public static List<BsonDocument>? Find(string? CollectionName, string? Filter, string? Project)
        {
            var MDBclient = new MongoClient(GlobalVariables.Variables.MDBCred.client);
            var MDBdatabase = MDBclient.GetDatabase(GlobalVariables.Variables.MDBCred.database);
            var MDBcollection = MDBdatabase.GetCollection<BsonDocument>(CollectionName);

            var FindData = MDBcollection.Find(Filter)
                                        .Project(Project)
                                        .ToList();

            return FindData;
        }
    }
}
