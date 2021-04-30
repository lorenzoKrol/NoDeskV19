using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TGG_Model
{
    public class IdGenerator
    {
        [BsonId]
        private ObjectId id { get; set; }

        public IdGenerator()
        {
            this.id = ObjectId.GenerateNewId();
        }
        public ObjectId GetId()
        {
            return id;
        }

    }
}
