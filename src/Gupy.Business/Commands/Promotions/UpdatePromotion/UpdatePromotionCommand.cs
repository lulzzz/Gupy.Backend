using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Commands.Promotions.UpdatePromotion
{
    public class UpdatePromotionCommand : IRequest<PromotionDto>
    {
        public int ProductId { get; set; }
        public PromotionDto PromotionDto { get; set; }
    }
}