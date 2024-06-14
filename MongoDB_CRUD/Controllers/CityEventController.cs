using Microsoft.AspNetCore.Mvc;
using MongoDB_CRUD.Models;
using MongoDB_CRUD.Repository;
using MongoDB_CRUD.Services;
using System.Threading.Tasks;

namespace MongoDB_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityEventController : ControllerBase
    {
      
       
            private readonly ICityEventRepository _cityEventRepository;
            public CityEventController(ICityEventRepository cityEventRepository)
            {
                _cityEventRepository = cityEventRepository;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                return Ok(await _cityEventRepository.GetAllCity().ConfigureAwait(false));
            }
            [HttpGet("{id:length(24)}")]
            public async Task<IActionResult> Get(string id)
            {
                var cityEvent = await _cityEventRepository.GetByIdCity(id).ConfigureAwait(false);
                if (cityEvent == null)
                {
                    return NotFound();
                }
                return Ok(cityEvent);
            }
            [HttpPost]
            public async Task<IActionResult> Create(CityEvent cityEvent)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _cityEventRepository.CreateCity(cityEvent).ConfigureAwait(false);
                return Ok(cityEvent.Id);
            }

            [HttpPut("{id:length(24)}")]
            public async Task<IActionResult> UpdateCity(string id, CityEvent cityEventIn)
            {
                var cityEvent = await _cityEventRepository.GetByIdCity(id).ConfigureAwait(false);
                if (cityEvent == null)
                {
                    return NotFound();
                }
                await _cityEventRepository.UpdateCity(id, cityEventIn).ConfigureAwait(false);
                return NoContent();
            }

            [HttpDelete("{id:length(24)}")]
            public async Task<IActionResult> Delete(string id)
            {
                var user = await _cityEventRepository.GetByIdCity(id).ConfigureAwait(false);
                if (user == null)
                {
                    return NotFound();
                }
                await _cityEventRepository.DeleteCity(id).ConfigureAwait(false);
                return NoContent();
            }
        }
    }

