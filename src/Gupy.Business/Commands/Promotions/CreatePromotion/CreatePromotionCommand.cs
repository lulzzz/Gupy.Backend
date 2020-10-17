using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Commands.Promotions.CreatePromotion
{
    public class CreatePromotionCommand : IRequest<PromotionDto>
    {
        public int ProductId { get; set; }
        public PromotionDto PromotionDto { get; set; }
    }
}