using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_CRUD.Models;
using MongoDB_CRUD.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB_CRUD.Services
{
    public class DetailEventService : IDetailEventRepository
    {
        private readonly IMongoCollection<DetailsEvent> _collection;
        private readonly DbConfiguration _settings;
        public DetailEventService(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<DetailsEvent>("events");
        }

        public async Task<DetailsEvent> CreateDetail(DetailsEvent detailsEvent)
        {
            await _collection.InsertOneAsync(detailsEvent).ConfigureAwait(false);
            return detailsEvent;
        }

        public  Task DeleteDetail(string id)
        {
            return _collection.DeleteOneAsync(c => c.Id == id);
        }

        public Task<List<DetailsEvent>> GetAllDetail()
        {
            return _collection.Find(c => true).ToListAsync();
        }

        public Task<DetailsEvent> GetByIdDetail(string id)
        {
            return _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public Task UpdateDetail(string id, DetailsEvent detailsEvent)
        {
            return _collection.ReplaceOneAsync(c => c.Id == id, detailsEvent);
        }
    }
}
