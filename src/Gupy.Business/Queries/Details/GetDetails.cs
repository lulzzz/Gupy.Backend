using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Business.Specifications.ShippingDetails;
using Gupy.Core.Common;
using Gupy.Core.Dtos;
using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;
using MediatR;

namespace Gupy.Business.Queries.Details
{
    public class GetDetailsQuery : IRequest<List<ShippingDetailsDto>>
    {
        public int? TelegramUserId { get; set; }
    }

    public class GetDetailsQueryHandler : IRequestHandler<GetDetailsQuery, List<ShippingDetailsDto>>
    {
        private readonly IShippingDetailsRepository _detailsRepository;
        private readonly IMapper _mapper;

        public GetDetailsQueryHandler(IShippingDetailsRepository detailsRepository, IMapper mapper)
        {
            _detailsRepository = detailsRepository;
            _mapper = mapper;
        }

        public async Task<List<ShippingDetailsDto>> Handle(GetDetailsQuery request, CancellationToken cancellationToken)
        {
            var specifications = new List<Specification<ShippingDetails>>();
            if (request.TelegramUserId != null)
            {
                specifications.Add(new ShippingDetailsOfUserSpecification(request.TelegramUserId.Value));
            }

            var details = await _detailsRepository.ListAsync(specifications: specifications.ToArray());

            var result = _mapper.Map<List<ShippingDetailsDto>>(details);
            return result;
        }
    }
}