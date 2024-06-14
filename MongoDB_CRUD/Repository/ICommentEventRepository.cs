using MongoDB_CRUD.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB_CRUD.Repository
{
    public interface ICommentEventRepository
    {
        Task<List<CommentEvent>> GetAllComment();
        Task<CommentEvent> GetByIdComment(string id);
        Task<CommentEvent> CreateComment(CommentEvent commentEvent);
        Task UpdateComment(string id, CommentEvent commentEvent);
        Task DeleteComment(string id);
    }
}
