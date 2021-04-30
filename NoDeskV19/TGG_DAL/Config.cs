using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace NoDesk
{
    public class Config
    {
        public MongoClient dbClient;
        public Config()
        {
            this.dbClient = new MongoClient("mongodb+srv://admin:mongo666@cluster0-z0hmx.azure.mongodb.net/test?retryWrites=true&w=majority");
        }
    }
}
