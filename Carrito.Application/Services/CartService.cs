using AutoMapper;
using Carrito.Application.DTOs;
using Carrito.Application.Interfaces.Services;
using Carrito.Application.Interfaces.UnitOfWork;
using Carrito.Domain.Entities;

namespace Carrito.Application.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CartDto> AddToCartAsync(AddToCartDto addToCartDto)
        {
            var cart = await _unitOfWork.CartsRepository.GetByIdAsync(addToCartDto.CartId);
            if (cart == null) return null;

            var product = await _unitOfWork.ProductsRepository.GetByIdAsync(addToCartDto.ProductId);
            if (product == null) return null;

            var cartProduct = cart.CartProducts.FirstOrDefault(cp => cp.ProductId == product.Id);
            if (cartProduct == null)
            {
                cartProduct = new CartProduct
                {
                    CartId = cart.Id,
                    ProductId = product.Id,
                    Amount = 1,
                    UnitPrice = product.Price
                };
                cart.CartProducts.Add(cartProduct);
            }
            else
            {
                cartProduct.Amount += 1;
            }

            cart.Total = cart.CartProducts.Sum(cp => cp.Amount * cp.UnitPrice);
            await _unitOfWork.CartsRepository.UpdateAsync(cart);

            var cartDto = _mapper.Map<CartDto>(cart);
            return cartDto;
        }

        public async Task<int> CreateCartAsync(string dni)
        {
            if (string.IsNullOrEmpty(dni))
                return 0;

            var user = await _unitOfWork.UsersRepository.GetByDniAsync(dni);
            if (user == null) return 0;

            string tipoCarrito;
            bool fechaEspecial = EsFechaPromocionable();
            if (user.VIP)
            {
                tipoCarrito = "Vip";
            }
            else if (fechaEspecial)
            {
                tipoCarrito = "PromocionablePorFecha";
            }
            else
            {
                tipoCarrito = "Comun";
            }

            var newCart = new Cart
            {
                UserId = user.Id,
                CreationDate = DateTime.UtcNow,
                Type = tipoCarrito,
                Total = 0m
            };

            await _unitOfWork.CartsRepository.CreateAsync(newCart);
            return newCart.Id;
        }

        public async Task<bool> DeleteCartAsync(int id)
        {
            var cart = await _unitOfWork.CartsRepository.GetByIdAsync(id);
            if (cart == null) return false;

            await _unitOfWork.CartsRepository.DeleteAsync(cart);
            await _unitOfWork.CommitAsync();

            return true;
        }


        public async Task<List<CartDto>> GetAllCartsAsync()
        {
            var carts = await _unitOfWork.CartsRepository.GetAllAsync();
            if (carts == null || !carts.Any()) return new List<CartDto>();

            return _mapper.Map<List<CartDto>>(carts);
        }

        public async Task<GetCartDto> GetCartByIdAsync(int cartId)
        {
            var cart = await _unitOfWork.CartsRepository.GetByIdAsync(cartId);
            if (cart == null) return null;

            decimal descuento = cart.CalculateDiscount();
            decimal totalConDescuento = cart.CalculateTotal() - descuento;

            var cartDto = _mapper.Map<GetCartDto?>(cart);
            cartDto.Descuento = descuento;
            cartDto.TotalConDescuento = totalConDescuento;

            return cartDto;
        }
        public async Task<List<ProductDto>> GetExpensiveProductsAsync(string dni)
        {
            var user = await _unitOfWork.UsersRepository.GetByDniAsync(dni);

            if (user == null)
                return null;

            var carts = await _unitOfWork.CartsRepository.GetCartsByUserIdAsync(user.Id);

            if (carts == null || !carts.Any())
                return null;

            var expensiveProducts = carts
                                    .SelectMany(c => c.CartProducts)
                                    .Select(cp => cp.Product)
                                    .OrderByDescending(p => p.Price)
                                    .Take(4)
                                    .Select(p => new ProductDto
                                    {
                                        Id = p.Id,
                                        Name = p.Name,
                                        Price = p.Price,
                                        Description = p.Description
                                    })
                                    .ToList();

            return expensiveProducts;
        }

        public async Task<CartDto> RemoveProductFromCartAsync(int productId, int cartId)
        {
            var cart = await _unitOfWork.CartsRepository.GetByIdAsync(cartId);
            if (cart == null) return null;

            var cartProduct = cart.CartProducts.FirstOrDefault(cp => cp.ProductId == productId);
            if (cartProduct == null) return null;

            cart.CartProducts.Remove(cartProduct);
            cart.Total = cart.CartProducts.Sum(cp => cp.Amount * cp.UnitPrice);

            await _unitOfWork.CartsRepository.UpdateAsync(cart);

            var cartDto = _mapper.Map<CartDto>(cart);
            return cartDto;
        }
        private bool EsFechaPromocionable()
        {
            var today = DateTime.Today;
            return (today.Month == 12 && today.Day == 18);
        }
    }
}
