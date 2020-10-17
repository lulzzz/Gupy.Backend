using MediatR;

namespace Gupy.Business.Commands.Categories.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public int CategoryId { get; set; }
    }
}