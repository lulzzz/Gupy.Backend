using System.Collections.Generic;
using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Queries.Details.GetDetails
{
    public class GetDetailsQuery : IRequest<List<ShippingDetailsDto>>
    {
        public int? TelegramUserId { get; set; }
    }
}