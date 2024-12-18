using Carrito.Application.DTOs;
using Carrito.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Carrito.API.Controllers
{
    [Route("api/v1/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }


        [HttpGet("{cartId}")]
        public async Task<IActionResult> GetByCartId(int cartId)
        {
            var cartResponse = await _cartService.GetCartByIdAsync(cartId);

            if (cartResponse == null)
                return NotFound();

            return Ok(cartResponse);
        }


        [HttpGet("get-expensive-products/{dni}")]
        public async Task<IActionResult> GetExpensiveProducts(string dni)
        {
            var expensiveProducts = await _cartService.GetExpensiveProductsAsync(dni);

            if (expensiveProducts == null || !expensiveProducts.Any())
                return NotFound("No se encontraron productos caros para el usuario.");

            return Ok(expensiveProducts);
        }


        [HttpGet("all-carts")]
        public async Task<IActionResult> GetAll()
        {
            var cartResponses = await _cartService.GetAllCartsAsync();

            if (cartResponses == null || !cartResponses.Any())
                return NotFound("No se encontraron carritos.");

            return Ok(cartResponses);
        }


        [HttpPost("create-cart/{dni}")]
        public async Task<IActionResult> CreateCart(string dni)
        {
            try
            {
                int cartId = await _cartService.CreateCartAsync(dni);
                return Ok(cartId);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("add-to-cart")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDto addToCartDto)
        {
            var updatedCart = await _cartService.AddToCartAsync(addToCartDto);

            if (updatedCart == null)
                return NotFound("Carrito o producto no encontrados.");

            return Ok(updatedCart);
        }

        [HttpDelete("delete-product/{productId}/{cartId}")]
        public async Task<IActionResult> DeleteProductToCart(int productId, int cartId)
        {
            var updatedCart = await _cartService.RemoveProductFromCartAsync(productId, cartId);

            if (updatedCart == null)
                return NotFound("Producto o carrito no encontrados.");

            return Ok(updatedCart);
        }


        [HttpDelete("borrar-cart/{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var success = await _cartService.DeleteCartAsync(id);

            if (!success)
                return NotFound("Carrito no encontrado.");

            return Ok($"El carrito {id} se borró exitosamente.");
        }

    }
}
