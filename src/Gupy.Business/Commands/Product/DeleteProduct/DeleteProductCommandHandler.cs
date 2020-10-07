using System.Threading;
using System.Threading.Tasks;
using Gupy.Business.Commands.DeletePhoto;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : AsyncRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMediator mediator)
        {
            _productRepository = productRepository;
            _mediator = mediator;
        }

        protected override async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(request.ProductId);
            if (product == null)
            {
                throw new NotFoundException(nameof(request.ProductId),
                    $"Product with such id ({request.ProductId})does not exist!");
            }

            if (!string.IsNullOrEmpty(product.Photo))
            {
                await _mediator.Send(new DeletePhotoCommand
                {
                    FileName = product.Photo
                });
            }

            _productRepository.Remove(product);
            await _productRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}