using Carrito.Application.DTOs;
using FluentValidation;

namespace Carrito.Application.Validators.Cart
{
    public class CreateUserDtoValidator : AbstractValidator<UserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Dni)
                .NotEmpty().WithMessage("El DNI no puede estar vacío.")
                .Matches(@"^\d{8}$");

            RuleFor(x => x.VIP)
                .NotNull().WithMessage("El estado VIP debe ser especificado.");
        }
    }
}
