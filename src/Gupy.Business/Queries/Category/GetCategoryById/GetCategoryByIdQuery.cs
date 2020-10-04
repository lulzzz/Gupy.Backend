using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Queries.Category.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<CategoryDto>
    {
        public int CategoryId { get; set; }
    }
}