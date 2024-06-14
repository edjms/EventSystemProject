using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_CRUD.Models;
using MongoDB_CRUD.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB_CRUD.Services
{
    public class PlaceEventService : IPlaceEventRepository
    {
        private readonly IMongoCollection<PlaceEvent> _collection;
        private readonly DbConfiguration _settings;
        public PlaceEventService(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<PlaceEvent>("locations");
        }

        public async Task<PlaceEvent> CreatePLace(PlaceEvent placeEvent)
        {
            await _collection.InsertOneAsync(placeEvent).ConfigureAwait(false);
            return placeEvent;
        }

        public Task DeletePLace(string id)
        {
            return _collection.DeleteOneAsync(c => c.Id == id);
        }

        public Task<List<PlaceEvent>> GetAllPLace()
        {
            return _collection.Find(c => true).ToListAsync();
        }

        public Task<PlaceEvent> GetByIdPLace(string id)
        {
            return _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public Task UpdatePLace(string id, PlaceEvent placeEvent)
        {
            return _collection.ReplaceOneAsync(c => c.Id == id, placeEvent);
        }
    }
}
