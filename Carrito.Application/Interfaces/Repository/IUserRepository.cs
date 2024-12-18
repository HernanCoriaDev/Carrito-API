using Carrito.Domain.Entities;

namespace Carrito.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetByDniAsync(string dni);
        Task<User> CreateAsync(User user);
        Task<List<User>> GetAllAsync();
    }
}
