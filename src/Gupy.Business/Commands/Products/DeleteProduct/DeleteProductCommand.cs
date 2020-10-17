using MediatR;

namespace Gupy.Business.Commands.Products.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public int ProductId { get; set; }
    }
}