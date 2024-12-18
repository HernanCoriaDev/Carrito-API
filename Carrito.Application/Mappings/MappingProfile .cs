using AutoMapper;
using Carrito.Application.DTOs;
using Carrito.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region Mapea las entidades de usuario
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<CreateUserDto, User>().ReverseMap();
        CreateMap<UserCartDto, User>().ReverseMap();
        #endregion

        #region Mapea los carritos
        CreateMap<Cart, CartDto>().ReverseMap();
        CreateMap<CartDto, Cart>().ReverseMap();
        CreateMap<Cart, GetCartDto>().ReverseMap();
        CreateMap<GetCartDto, Cart>().ReverseMap();
        #endregion

        #region Mapea productos del carrito
        CreateMap<CartProduct, CartProductDto>()
            .ForMember(p => p.ProductName, pn => pn.MapFrom(src => src.Product.Name))
            .ReverseMap();
        #endregion

        #region Mapea productos
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<ProductDto, Product>().ReverseMap();
        #endregion

        CreateMap<AddToCartDto, CartProduct>();
    }
}
