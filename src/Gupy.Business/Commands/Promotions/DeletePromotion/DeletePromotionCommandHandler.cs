using System.Threading;
using System.Threading.Tasks;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Commands.Promotions.DeletePromotion
{
    public class DeletePromotionCommandHandler : AsyncRequestHandler<DeletePromotionCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IPromotionRepository _promotionRepository;

        public DeletePromotionCommandHandler(IProductRepository productRepository,
            IPromotionRepository promotionRepository)
        {
            _productRepository = productRepository;
            _promotionRepository = promotionRepository;
        }

        protected override async Task Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductWithPromotionAsync(request.ProductId);
            if (product == null)
            {
                throw new NotFoundException(nameof(request.ProductId),
                    $"Product with id ({request.ProductId}) doesn't exist");
            }

            if (product.Promotion == null)
            {
                throw new NotFoundException(nameof(product.Promotion),
                    $"Product with id ({product.Id}) doesn't have a promotion");
            }

            _promotionRepository.Remove(product.Promotion);
            await _productRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}