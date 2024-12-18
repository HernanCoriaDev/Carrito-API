using Carrito.Application.DTOs;
using Carrito.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Carrito.API.Controllers
{
    [Route("api/v1/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost("create-products")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto productDto)
        {
            var product = await _productService.CreateProductAsync(productDto);
            return Ok(product);
        }


        [HttpGet("all-products")]
        public async Task<IActionResult> GetAllProduct()
        {
            var products = await _productService.GetAllProductsAsync();

            if (products == null || !products.Any())
                return NotFound("No se encontraron productos.");

            return Ok(products);
        }


    }
}
