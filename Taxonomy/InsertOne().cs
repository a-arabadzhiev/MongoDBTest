using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBCRUDExample
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://aarabadzhiev:#Zabrav1h@cluster0.urc9udb.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");

            var database = dbClient.GetDatabase("C#Test");
            var collection = database.GetCollection<BsonDocument>("Access Token");

            //            var document = new BsonDocument
            //            {
            //                { "access_token", "test" },
            //                { "expires", "test"}
            //            };

            //            collection.InsertOne(document);

            //            var firstDocument = collection.Find(new BsonDocument()).FirstOrDefault();
            //            Console.WriteLine(firstDocument.ToString());

        }
    }
}