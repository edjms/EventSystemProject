using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MongoDB_CRUD.Models;
using MongoDB_CRUD.Repository;
using System.Threading.Tasks;

namespace MongoDB_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentEventController:ControllerBase
    {
        private readonly ICommentEventRepository _commentEventRepository;
        public CommentEventController(ICommentEventRepository commentEventRepository)
        {
            _commentEventRepository = commentEventRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _commentEventRepository.GetAllComment().ConfigureAwait(false));
        }


        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var commentEvent = await _commentEventRepository.GetByIdComment(id).ConfigureAwait(false);
            if (commentEvent == null)
            {
                return NotFound();
            }
            return Ok(commentEvent);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CommentEvent commentEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _commentEventRepository.CreateComment(commentEvent).ConfigureAwait(false);
            return Ok(commentEvent.Id);
        }


        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdatePlace(string id, CommentEvent commentEventIn)
        {
            var commentEvent = await _commentEventRepository.GetByIdComment(id).ConfigureAwait(false);
            if (commentEvent == null)
            {
                return NotFound();
            }
            await _commentEventRepository.UpdateComment(id, commentEventIn).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var commentEventIn = await _commentEventRepository.GetByIdComment(id).ConfigureAwait(false);
            if (commentEventIn == null)
            {
                return NotFound();
            }
            await _commentEventRepository.DeleteComment(id).ConfigureAwait(false);
            return NoContent();
        }

    }
}
