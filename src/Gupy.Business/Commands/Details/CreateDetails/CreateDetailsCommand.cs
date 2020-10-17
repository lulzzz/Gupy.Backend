using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Commands.Details.CreateDetails
{
    public class CreateDetailsCommand : IRequest<ShippingDetailsDto>
    {
        public ShippingDetailsDto ShippingDetailsDto { get; set; }
    }
}