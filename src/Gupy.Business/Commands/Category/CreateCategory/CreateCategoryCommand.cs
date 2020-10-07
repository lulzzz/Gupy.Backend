using Gupy.Core.Dtos;
using Gupy.Core.Interfaces.Common;
using MediatR;

namespace Gupy.Business.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        public string Name { get; set; }
        public IFile Photo { get; set; }
    }
}