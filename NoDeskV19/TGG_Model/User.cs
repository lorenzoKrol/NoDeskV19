using System;
using MongoDB.Bson;

namespace TGG_Model
{
    public class User
    {
        public ObjectId Id;
        public string Email;
        public string Password;
        public string Name;
        public string Auth_code;
        public string Status;
    }
}
