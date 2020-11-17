using FluentValidation;
using Gupy.Api.Models.Product;

namespace Gupy.Api.Validators.Product
{
    public class CreateProductValidator : AbstractValidator<CreateProductModel>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name).MinimumLength(3).MaximumLength(55);

            RuleFor(p => p.Description).MinimumLength(20).MaximumLength(255);

            RuleFor(p => p.Price).GreaterThanOrEqualTo(1);

            RuleFor(p => p.CategoryId).GreaterThan(0);
        }
    }
}