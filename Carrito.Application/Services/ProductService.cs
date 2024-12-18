using AutoMapper;
using Carrito.Application.DTOs;
using Carrito.Application.Interfaces.Services;
using Carrito.Application.Interfaces.UnitOfWork;
using Carrito.Domain.Entities;

namespace Carrito.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateProductAsync(CreateProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description
            };

            await _unitOfWork.ProductsRepository.CreateAsync(product);
            await _unitOfWork.CommitAsync();

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.ProductsRepository.GetAllAsync();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description
            }).ToList();
        }

    }
}
