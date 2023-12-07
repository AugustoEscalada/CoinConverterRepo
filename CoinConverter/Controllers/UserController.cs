using CoinConverter.Models.DTO;

using CoinConverter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoinConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;
        public UserController(IUserServices userRepository)
        {
            _userService = userRepository;
        }

        [HttpPost]
        public IActionResult CreateUser(UserForCreationDto dto)
        {
            try
            {
                _userService.Create(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex + "error aca");
            }
            return Created("Created", dto);
        }
    }
}
