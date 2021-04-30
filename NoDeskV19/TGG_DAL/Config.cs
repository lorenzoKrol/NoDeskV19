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
            this.dbClient = new MongoClient("");
        }
    }
}
