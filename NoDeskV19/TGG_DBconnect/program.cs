using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace test
{
    class program
    {
        static void Main(string[] args)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://admin:mongo666@cluster0-z0hmx.azure.mongodb.net/test?retryWrites=true&w=majority");
            // MongoClient dbClient = new MongoClient("mongodb+srv://mb0902:something@clustermuskan1-kig4u.azure.mongodb.net/test?retryWrites=true&w=majority");
            var dbList = dbClient.ListDatabases().ToList();

            var database = dbClient.GetDatabase("NoDesk");
            var collection = database.GetCollection<BsonDocument>(" ");

            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }
            Console.ReadKey();
        }
    }
}