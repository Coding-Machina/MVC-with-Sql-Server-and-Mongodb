using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.DAL
{
    public class BlogMongo
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string BlogTitle { get; set; }
        public string BlogDate { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public string Synced { get; set; }
    }
}
