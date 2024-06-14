using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB_CRUD.Models;
using MongoDB_CRUD.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB_CRUD.Services
{
    public class CityEventService : ICityEventRepository
    {
        private readonly IMongoCollection<CityEvent> _collection;
        private readonly DbConfiguration _settings;
        public CityEventService(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<CityEvent>("city");
        }

        public async Task<CityEvent> CreateCity(CityEvent cityEvent)
        {
            // await _collection.InsertOneAsync(cityEvent).ConfigureAwait(false);
            // return cityEvent;
            await _collection.InsertOneAsync(cityEvent);
            Console.WriteLine($"NoSQL Query: {{ insert: 'CityEvents', documents: [ {cityEvent.ToJson()} ] }}");
            return cityEvent;
        }

        Task ICityEventRepository.DeleteCity(string id)
        {
            return _collection.DeleteOneAsync(c => c.Id == id);
        }

        Task<List<CityEvent>> ICityEventRepository.GetAllCity()
        {
           // return _collection.Find(c => true).ToListAsync();
           string nosqlQuery = "{ find: 'CityEvents' }";
            Console.WriteLine("NoSQL Query: " + nosqlQuery);
            return  _collection.Find(new BsonDocument()).ToListAsync();
        }

        Task<CityEvent> ICityEventRepository.GetByIdCity(string id)
        {
            return _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        Task ICityEventRepository.UpdateCity(string id, CityEvent cityEvent)
        {
            return _collection.ReplaceOneAsync(c => c.Id == id, cityEvent);
        }
    }
}
