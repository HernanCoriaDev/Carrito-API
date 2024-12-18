using Carrito.Application.DTOs;

namespace Carrito.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<ProductDto> CreateProductAsync(CreateProductDto productDto);
        Task<List<ProductDto>> GetAllProductsAsync();

    }
}
