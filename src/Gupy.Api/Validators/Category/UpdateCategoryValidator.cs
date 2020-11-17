using FluentValidation;
using Gupy.Api.Models.Category;

namespace Gupy.Api.Validators.Category
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryModel>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(c => c.Name).MinimumLength(3).MaximumLength(55);
        }
    }
}