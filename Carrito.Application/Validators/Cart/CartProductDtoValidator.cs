using Carrito.Application.DTOs;
using FluentValidation;

namespace Carrito.Application.Validators.Cart
{
    public class CartProductDtoValidator : AbstractValidator<CartProductDto>
    {
        public CartProductDtoValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("El ProductId debe ser un valor mayor que 0.");

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("El nombre del producto no puede estar vacío.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("La cantidad debe ser mayor que 0.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("El precio unitario debe ser mayor que 0.");
        }
    }
}
