using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Core.Dtos;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;
using MediatR;

namespace Gupy.Business.Commands.Promotions.CreatePromotion
{
    public class CreatePromotionHandler : IRequestHandler<CreatePromotionCommand, PromotionDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreatePromotionHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<PromotionDto> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductWithPromotionAsync(request.ProductId);
            if (product == null)
            {
                throw new NotFoundException(nameof(request.PromotionDto.ProductId),
                    $"Product with id ({request.PromotionDto.ProductId}) doesn't exist");
            }

            if (product.Promotion != null)
            {
                throw new NotValidException(nameof(product.Promotion),
                    $"Product with id ({product.Id}) already has a promotion");
            }
            
            var promotion = _mapper.Map<Promotion>(request.PromotionDto);
            product.Promotion = promotion;
            await _productRepository.UnitOfWork.SaveChangesAsync();

            var result = _mapper.Map<PromotionDto>(promotion);
            return result;
        }
    }
}