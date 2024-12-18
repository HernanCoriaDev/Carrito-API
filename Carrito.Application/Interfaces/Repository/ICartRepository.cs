using Carrito.Application.DTOs;
using Carrito.Domain.Entities;

namespace Carrito.Application.Interfaces.Repository
{
    public interface ICartRepository
    {
        Task<Cart> GetByIdAsync(int cartId);
        Task<Cart> CreateAsync(Cart cart);
        Task UpdateAsync(Cart cart);
        Task DeleteAsync(Cart cart);
        Task<List<Cart>> GetAllAsync();
        Task<List<Cart>> GetCartsByUserIdAsync(int userId);

    }

}
