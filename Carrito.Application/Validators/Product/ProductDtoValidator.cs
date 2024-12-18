using Carrito.Application.DTOs;
using FluentValidation;

namespace Carrito.Application.Validators.Product
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre del producto no puede estar vacío.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("El precio debe ser mayor que 0.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("La descripción no puede estar vacía.");
        }
    }
}
