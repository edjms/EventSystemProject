using MongoDB_CRUD.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB_CRUD.Repository
{
    public interface ICityEventRepository
    {
        Task<List<CityEvent>> GetAllCity();
        Task<CityEvent> GetByIdCity(string id);
        Task<CityEvent> CreateCity(CityEvent cityEvent);
        Task UpdateCity(string id, CityEvent cityEvent);
        Task DeleteCity(string id);
    }
}

