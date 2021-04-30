using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace NoDesk
{
    public class DAO_PassReset

    {
        public Config config;

        public DAO_PassReset()
        {
            config = new Config();
        }
        public string Select()
        {
            string result = "";
            var dbList = config.dbClient.ListDatabases().ToList();
            foreach (var db in dbList)
            {
                result = result + " " + db;
            }
            return result;
        }

        public void InsertAuthCode(string Email, string Authcode)
        {
            //create DAO

            //select database and collection
            var database = config.dbClient.GetDatabase("NoDesk");
            var collection = database.GetCollection<BsonDocument>("Users");
            //create filter
            var filter = Builders<BsonDocument>.Filter.Eq("Email", Email);
            //update in database
            var update = Builders<BsonDocument>.Update.Set("Auth_code", Authcode);
            collection.UpdateOne(filter, update);
        }

        public List<BsonDocument> GetAuthCode(string email)
        {
            //select database and collection
            var database = config.dbClient.GetDatabase("NoDesk");
            var collection = database.GetCollection<BsonDocument>("Users");
            //create filter
            var filter = Builders<BsonDocument>.Filter.Eq("Email", email);
            //add all documents found to list
            var documents = collection.Find(filter).ToList();

            return documents;
        }

        public bool InsertPassword(string email, string Password)
        {
            bool InsertPasswordCheck = false;

            
            //insert into database
            var database = config.dbClient.GetDatabase("NoDesk");
            var collection = database.GetCollection<BsonDocument>("Users");
            //create filter
            var filter = Builders<BsonDocument>.Filter.Eq("Email", email);
            //update in database
            var update = Builders<BsonDocument>.Update.Set("Password", Password);
            collection.UpdateOne(filter, update);

            //remove authcode from datbase
            var update_auth_code = Builders<BsonDocument>.Update.Set("Auth_code", "0");
            collection.UpdateOne(filter, update_auth_code);
            //do check if everything goes well
            InsertPasswordCheck = true;

            if (InsertPasswordCheck)
            {
                return true;
            }
            else

            return false;
        }
    }
}
