using Gupy.Core.Dtos;
using Gupy.Core.Interfaces.Common;
using MediatR;

namespace Gupy.Business.Commands.Product.CreateProduct
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public ProductDto ProductDto { get; set; }
        public IFile Photo { get; set; }
    }
}