using Microsoft.Extensions.Options;
using MinimalAPI.MongoDB.Models.Database;
using MongoDB.Driver;

namespace MinimalAPI.MongoDB.Data.Contexts
{
    public class MongoContext
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        public MongoContext(IOptions<ClientesDatabaseSettings> dbOptions)
        {
            var settings = dbOptions.Value;
            _client = new MongoClient(settings.ConnectionString);
            _database = _client.GetDatabase(settings.DatabaseName);
        }

        public IMongoClient Client => _client;

        public IMongoDatabase Database => _database;
    }
}
