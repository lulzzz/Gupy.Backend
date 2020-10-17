using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Queries.Details.GetDetailsById
{
    public class GetDetailsByIdQuery : IRequest<ShippingDetailsDto>
    {
        public int ShippingDetailsId { get; set; }
    }
}