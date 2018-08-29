using Mongo.DAL.Properties;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.DAL
{
    public class BlogContext
    {
        public IMongoDatabase Database;

        public BlogContext()
        {
            var ConnectionString = Settings.Default.DBConnectionString;
            var settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
            var Client = new MongoClient(settings);
            Database = Client.GetDatabase(Settings.Default.DatabaseName);
        }
        public IMongoCollection<BlogMongo> mongoCollection => Database.GetCollection<BlogMongo>("blog1234");

    }
}
