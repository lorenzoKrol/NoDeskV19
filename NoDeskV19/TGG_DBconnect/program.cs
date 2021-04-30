using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace test
{
    class program
    {
        static void Main(string[] args)
        {
            MongoClient dbClient = new MongoClient("");
            
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
