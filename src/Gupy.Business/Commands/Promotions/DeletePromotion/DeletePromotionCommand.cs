using MediatR;

namespace Gupy.Business.Commands.Promotions.DeletePromotion
{
    public class DeletePromotionCommand : IRequest
    {
        public int ProductId { get; set; }
    }
}