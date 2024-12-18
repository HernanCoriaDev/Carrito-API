using Carrito.Application.DTOs;
using FluentValidation;

namespace Carrito.Application.Validators.Cart
{
    public class GetCartDtoValidator : AbstractValidator<GetCartDto>
    {
        public GetCartDtoValidator()
        {
            RuleFor(x => x.TotalOriginal)
                .GreaterThanOrEqualTo(0).WithMessage("El total original debe ser mayor o igual a 0.");

            RuleFor(x => x.Descuento)
                .GreaterThanOrEqualTo(0).WithMessage("El descuento debe ser mayor o igual a 0.");

            RuleFor(x => x.TotalConDescuento)
                .GreaterThanOrEqualTo(0).WithMessage("El total con descuento debe ser mayor o igual a 0.");
        }
    }
}
