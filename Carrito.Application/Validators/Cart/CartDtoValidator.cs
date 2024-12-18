using Carrito.Application.DTOs;
using FluentValidation;

namespace Carrito.Application.Validators.Cart
{
    public class CartDtoValidator : AbstractValidator<CartDto>
    {
        public CartDtoValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("El UserId debe ser un valor mayor que 0.");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("El tipo de carrito no puede estar vacío.");

            RuleFor(x => x.Total)
                .GreaterThanOrEqualTo(0).WithMessage("El total debe ser mayor o igual a 0.");
        }
    }
}
