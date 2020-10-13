using MediatR;

namespace Gupy.Business.Commands.ShippingDetails.DeleteDetails
{
    public class DeleteDetailsCommand : IRequest
    {
        public int ShippingDetailsId { get; set; }
    }
}