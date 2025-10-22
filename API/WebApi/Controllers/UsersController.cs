using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApi.Interface;

namespace WebApi.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
           
            var user = await _userRepository.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
