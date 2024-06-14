using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_CRUD.Models;
using MongoDB_CRUD.Repository;

namespace MongoDB_CRUD.Services
{
    public class UserService : IUserRepository
    {
        private readonly IMongoCollection<User> _collection;
        private readonly DbConfiguration _settings;
        public UserService(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<User>("user");
        }

        public Task<List<User>> GetAllAsync()
        {
            return _collection.Find(c => true).ToListAsync();
        }
        public Task<User> GetByIdAsync(string id)
        {
            return _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<User> CreateAsync(User user)
        {
            await _collection.InsertOneAsync(user).ConfigureAwait(false);
            return user;
        }
        public Task UpdateAsync(string id, User user)
        {
            return _collection.ReplaceOneAsync(c => c.Id == id, user);
        }
        public Task DeleteAsync(string id)
        {
            return _collection.DeleteOneAsync(c => c.Id == id);
        }
    }
}
