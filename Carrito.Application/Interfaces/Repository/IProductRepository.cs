using Carrito.Domain.Entities;

namespace Carrito.Application.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<List<Product>> GetAllAsync();
    }
}
