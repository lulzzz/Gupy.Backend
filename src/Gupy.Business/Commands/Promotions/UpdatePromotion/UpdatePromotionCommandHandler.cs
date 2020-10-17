using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Core.Dtos;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Commands.Promotions.UpdatePromotion
{
    public class UpdatePromotionCommandHandler : IRequestHandler<UpdatePromotionCommand, PromotionDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdatePromotionCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<PromotionDto> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
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

            _mapper.Map(request.PromotionDto, product.Promotion);
            await _productRepository.UnitOfWork.SaveChangesAsync();

            var result = _mapper.Map<PromotionDto>(product.Promotion);
            return result;
        }
    }
}