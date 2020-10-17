using MediatR;

namespace Gupy.Business.Commands.Details.DeleteDetails
{
    public class DeleteDetailsCommand : IRequest
    {
        public int ShippingDetailsId { get; set; }
    }
}