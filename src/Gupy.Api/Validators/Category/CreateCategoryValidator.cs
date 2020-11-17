using FluentValidation;
using Gupy.Api.Models.Category;

namespace Gupy.Api.Validators.Category
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryModel>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.Name).MinimumLength(3).MaximumLength(55);
        }
    }
}