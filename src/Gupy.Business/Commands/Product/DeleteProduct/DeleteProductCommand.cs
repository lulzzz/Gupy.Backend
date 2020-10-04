using MediatR;

namespace Gupy.Business.Commands.Product.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public int ProductId { get; set; }
    }
}