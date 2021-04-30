using System;
using TGG_Model;
using NoDesk;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System.Linq;
using System.Collections.Generic;

namespace TGG_DAL
{
    public class User_DAO
    {

        //Connection file that makes a connection when created
        public Config config = new Config();
        //get single user
        public User GetUser(string username)
        {
            try
            {
                var database = config.dbClient.GetDatabase("NoDesk");
                var collection = database.GetCollection<User>("Users");
                var filter = Builders<User>.Filter.Eq("Email", username);

                var user = collection.Find(filter).FirstOrDefault<User>();
                if (user == null)
                {
                    return null;
                }
                else
                {
                    return user;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error : " + e);//added exception code
            }
        }
        //if check existence is true then call get user by name
        public User verifyUserCredentials(string username, string password)
        {
            try
            {

                var database = config.dbClient.GetDatabase("NoDesk");
                var collection = database.GetCollection<User>("Users");
                var filter = Builders<User>.Filter.Eq("Email", username);

                var user = collection.Find(filter).FirstOrDefault<User>();
                if (user == null)
                {
                    return null;
                }
                else if ((username == user.Email) && (password == user.Password))
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error : " + e);//added exception code
            }
        }
        //get all users
        public List<User> GetAllUsers()
        {
            try
            {
                var database = config.dbClient.GetDatabase("NoDesk");
                var collection = database.GetCollection<User>("Users");
                var users = collection.Find(new BsonDocument()).ToList();
                return users;
            }
            catch (Exception e)
            {
                throw new Exception(" " + e.Message);
            }
        }
        //update user
        public void UpdateUser(string originalEmail, string email, string name, string password, string status)
        {
            try
            {
                var database = config.dbClient.GetDatabase("NoDesk");
                var collection = database.GetCollection<BsonDocument>("Users");
                var filter = Builders<BsonDocument>.Filter.Eq("Email", originalEmail);
                //update in database
                var update = Builders<BsonDocument>.Update.Set("Email", email).Set("Password", password).Set("Name", name).Set("Status", status);
                collection.UpdateOne(filter, update);
            }
            catch (Exception e)
            {
                throw new Exception(" " + e.Message);
            }
        }
        //add user
        public void AddUser(string email, string name, string password, string status)
        {
            try
            {
                var database = config.dbClient.GetDatabase("NoDesk");
                var collection = database.GetCollection<BsonDocument>("Users");
                var document = new BsonDocument
            {
                {"Email",email},
                {"Password",password},
                {"Name",name},
                {"Auth_code","0"},
                {"Status",status}
            };

                collection.InsertOneAsync(document);
            }
            catch (Exception e)
            {
                throw new Exception(" " + e.Message);
            }
        }
        //delete user
        public void DeleteUser(string email)
        {
            try
            {
                var database = config.dbClient.GetDatabase("NoDesk");
                var collection = database.GetCollection<BsonDocument>("Users");
                var filter = Builders<BsonDocument>.Filter.Eq("Email", email);
                collection.DeleteOne(filter);
            }
            catch (Exception e)
            {
                throw new Exception(" " + e.Message);
            }
        }
    }
}



