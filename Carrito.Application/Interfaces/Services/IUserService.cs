using Carrito.Application.DTOs;

namespace Carrito.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<CreateUserDto> CreateUserAsync(UserDto dto);
        Task<UserCartDto> GetUserByIdAsync(int id);
        Task<List<UserCartDto>> GetAllUsersAsync();

    }
}
