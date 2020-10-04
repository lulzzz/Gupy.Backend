using MediatR;

namespace Gupy.Business.Commands.Category.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public int CategoryId { get; set; }
    }
}