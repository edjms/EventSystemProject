using MongoDB_CRUD.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB_CRUD.Repository
{
    public interface IDetailEventRepository
    {
        Task<List<DetailsEvent>> GetAllDetail();
        Task<DetailsEvent> GetByIdDetail(string id);
        Task<DetailsEvent> CreateDetail(DetailsEvent detailsEvent);
        Task UpdateDetail(string id, DetailsEvent detailsEvent);
        Task DeleteDetail(string id);
    }
}
