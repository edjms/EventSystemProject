using Microsoft.AspNetCore.Mvc;
using MongoDB_CRUD.Models;
using MongoDB_CRUD.Repository;
using System.Threading.Tasks;

namespace MongoDB_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceEventController:ControllerBase
    {
        private readonly IPlaceEventRepository _placeEventRepository;
        public PlaceEventController(IPlaceEventRepository placeEventRepository)
        {
            _placeEventRepository = placeEventRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _placeEventRepository.GetAllPLace().ConfigureAwait(false));
        }


        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var placeEvent = await _placeEventRepository.GetByIdPLace(id).ConfigureAwait(false);
            if (placeEvent == null)
            {
                return NotFound();
            }
            return Ok(placeEvent);
        }
        [HttpPost]
        public async Task<IActionResult> Create(PlaceEvent placeEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _placeEventRepository.CreatePLace(placeEvent).ConfigureAwait(false);
            return Ok(placeEvent.Id);
        }


        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdatePlace(string id, PlaceEvent placeEventIn)
        {
            var cityEvent = await _placeEventRepository.GetByIdPLace(id).ConfigureAwait(false);
            if (cityEvent == null)
            {
                return NotFound();
            }
            await _placeEventRepository.UpdatePLace(id, placeEventIn).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _placeEventRepository.GetByIdPLace(id).ConfigureAwait(false);
            if (user == null)
            {
                return NotFound();
            }
            await _placeEventRepository.DeletePLace(id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
