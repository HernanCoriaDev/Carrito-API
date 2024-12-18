using Carrito.Application.DTOs;
using Carrito.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Carrito.API.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
       

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userResponses = await _userService.GetAllUsersAsync();

            if (userResponses == null || !userResponses.Any())
                return NotFound("No se encontraron usuarios.");

            return Ok(userResponses);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userResponse = await _userService.GetUserByIdAsync(id);

            if (userResponse == null)
                return NotFound($"Usuario con ID {id} no encontrado.");

            return Ok(userResponse);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDto dto)
        {
            var userResponse = await _userService.CreateUserAsync(dto);

            if (userResponse == null)
                return BadRequest("Error al crear el usuario.");

            return CreatedAtAction(nameof(GetAll), new { userResponse.Id }, userResponse);
        }

    }
}
