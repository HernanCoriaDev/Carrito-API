using Carrito.Application.DTOs;

namespace Carrito.Application.Interfaces.Services
{
    public interface ICartService
    {
        Task<int> CreateCartAsync(string dni);
        Task<GetCartDto> GetCartByIdAsync(int cartId);
        Task<CartDto> AddToCartAsync(AddToCartDto addToCartDto);
        Task<CartDto> RemoveProductFromCartAsync(int productId, int cartId);
        Task<bool> DeleteCartAsync(int cartId);
        Task<List<CartDto>> GetAllCartsAsync();
        Task<List<ProductDto>> GetExpensiveProductsAsync(string dni);

    }
}
