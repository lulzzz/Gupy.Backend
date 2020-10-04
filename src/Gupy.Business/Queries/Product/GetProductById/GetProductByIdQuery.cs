using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Queries.Product.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public int ProductId { get; set; }
    }
}