using System;
using FluentValidation;
using Gupy.Api.Models.Product;

namespace Gupy.Api.Validators.Product
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductModel>
    {
        public UpdateProductValidator()
        {
            RuleFor(p => p.Id).GreaterThan(0);

            RuleFor(p => p.Name).MinimumLength(3).MaximumLength(55);

            RuleFor(p => p.Description).MinimumLength(20).MaximumLength(255);

            RuleFor(p => p.Price).GreaterThanOrEqualTo(1);

            RuleFor(p => p.CategoryId).GreaterThan(0);

            RuleFor(p => p.PromotionPrice).GreaterThanOrEqualTo(1).LessThan(p => p.Price)
                .When(p => p.PromotionPrice != null);
            RuleFor(p => p.PromotionPrice).NotNull().When(p => p.PromotionEndDate != null);

            RuleFor(p => p.PromotionEndDate).InclusiveBetween(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddMonths(3))
                .When(p => p.PromotionEndDate != null);
            RuleFor(p => p.PromotionEndDate).NotNull().When(p => p.PromotionPrice != null);
        }
    }
}