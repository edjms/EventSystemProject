using MongoDB_CRUD.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB_CRUD.Repository
{
    public interface IPlaceEventRepository
    {
        Task<List<PlaceEvent>> GetAllPLace();
        Task<PlaceEvent> GetByIdPLace(string id);
        Task<PlaceEvent> CreatePLace(PlaceEvent placeEvent);
        Task UpdatePLace(string id, PlaceEvent placeEvent);
        Task DeletePLace(string id);
    }
}
