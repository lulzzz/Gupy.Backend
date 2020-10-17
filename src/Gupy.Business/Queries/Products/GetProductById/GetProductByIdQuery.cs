using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Queries.Products.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public int ProductId { get; set; }
    }
}