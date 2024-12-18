using Carrito.Application.DTOs;
using FluentValidation;

namespace Carrito.Application.Validators.Cart
{
    internal class AddToCartDtoValidator : AbstractValidator<AddToCartDto>
    {
        public AddToCartDtoValidator()
        {
            RuleFor(x => x.CartId)
                .GreaterThan(0).WithMessage("El CartId debe ser un valor mayor que 0.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("El ProductId debe ser un valor mayor que 0.");
        }
    }
}
