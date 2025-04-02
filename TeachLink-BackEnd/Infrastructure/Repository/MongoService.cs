using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace TeachLink_BackEnd.Infrastructure.Services
{
    public abstract class MongoService<T>
    {
        protected readonly IMongoCollection<T> _collection;

        protected MongoService(IOptions<MongoSettings> dbSettings, string collectionName)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var database = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _collection = database.GetCollection<T>(collectionName);
        }
    }
}
