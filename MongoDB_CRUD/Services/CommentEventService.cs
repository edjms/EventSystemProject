using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_CRUD.Models;
using MongoDB_CRUD.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB_CRUD.Services
{
    public class CommentEventService : ICommentEventRepository
    {
        private readonly IMongoCollection<CommentEvent> _collection;
        private readonly DbConfiguration _settings;
        public CommentEventService(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<CommentEvent>("comments");
        }

        public async Task<CommentEvent> CreateComment(CommentEvent commentEvent)
        {
            await _collection.InsertOneAsync(commentEvent).ConfigureAwait(false);
            return commentEvent;
        }

        public Task DeleteComment(string id)
        {
            return _collection.DeleteOneAsync(c => c.Id == id);
        }

        public Task<List<CommentEvent>> GetAllComment()
        {
            return _collection.Find(c => true).ToListAsync();
        }

        public Task<CommentEvent> GetByIdComment(string id)
        {
            return _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public Task UpdateComment(string id, CommentEvent commentEvent)
        {
            return _collection.ReplaceOneAsync(c => c.Id == id, commentEvent);
        }
    }
}
