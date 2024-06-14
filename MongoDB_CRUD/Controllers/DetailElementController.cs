using Microsoft.AspNetCore.Mvc;
using MongoDB_CRUD.Models;
using MongoDB_CRUD.Repository;
using System.Threading.Tasks;

namespace MongoDB_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailElementController:ControllerBase
    {
        private readonly IDetailEventRepository _detailEventRepository;
        public DetailElementController(IDetailEventRepository detailEventRepository)
        {
            _detailEventRepository = detailEventRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _detailEventRepository.GetAllDetail().ConfigureAwait(false));
        }


        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var detailEvent = await _detailEventRepository.GetByIdDetail(id).ConfigureAwait(false);
            if (detailEvent == null)
            {
                return NotFound();
            }
            return Ok(detailEvent);
        }


        [HttpPost]
        public async Task<IActionResult> Create(DetailsEvent detailsEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _detailEventRepository.CreateDetail(detailsEvent).ConfigureAwait(false);
            return Ok(detailsEvent.Id);
        }


        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdatePlace(string id, DetailsEvent detailsEventIn)
        {
            var detailsEvent = await _detailEventRepository.GetByIdDetail(id).ConfigureAwait(false);
            if (detailsEvent == null)
            {
                return NotFound();
            }
            await _detailEventRepository.UpdateDetail(id, detailsEventIn).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var detailsEvent = await _detailEventRepository.GetByIdDetail(id).ConfigureAwait(false);
            if (detailsEvent == null)
            {
                return NotFound();
            }
            await _detailEventRepository.DeleteDetail(id).ConfigureAwait(false);
            return NoContent();
        }

    }
}
