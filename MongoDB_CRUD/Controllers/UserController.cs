using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB_CRUD.Models;
using MongoDB_CRUD.Repository;


namespace MongoDB_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userRepository.GetAllAsync().ConfigureAwait(false));
        }
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _userRepository.GetByIdAsync(id).ConfigureAwait(false);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _userRepository.CreateAsync(user).ConfigureAwait(false);
            return Ok(user.Id);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, User userIn)
        {
            var user = await _userRepository.GetByIdAsync(id).ConfigureAwait(false);
            if (user == null)
            {
                return NotFound();
            }
            await _userRepository.UpdateAsync(id, userIn).ConfigureAwait(false);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userRepository.GetByIdAsync(id).ConfigureAwait(false);
            if (user == null)
            {
                return NotFound();
            }
            await _userRepository.DeleteAsync(user.Id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
