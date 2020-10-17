using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Queries.Categories.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<CategoryDto>
    {
        public int CategoryId { get; set; }
    }
}