using System.Threading;
using System.Threading.Tasks;
using Gupy.Business.Commands.Photos;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Commands.Products
{
    public class DeleteProductCommand : IRequest
    {
        public int ProductId { get; set; }
    }

    public class DeleteProductCommandHandler : AsyncRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        protected override async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(request.ProductId);
            if (product == null)
            {
                throw new NotFoundException(nameof(request.ProductId),
                    $"Product with such id ({request.ProductId})does not exist!");
            }

            product.SoftDeleted = true;
            await _productRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}