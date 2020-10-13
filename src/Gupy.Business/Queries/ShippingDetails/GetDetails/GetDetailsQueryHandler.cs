using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Business.Specifications;
using Gupy.Core.Common;
using Gupy.Core.Dtos;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Queries.ShippingDetails.GetDetails
{
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
            Specification<Domain.ShippingDetails> specification = null;
            if (request.TelegramUserId != null)
            {
                specification = new ShippingDetailsOfUserSpecification(request.TelegramUserId.Value);
            }

            var details = await _detailsRepository.ListAsync(specification);

            var result = _mapper.Map<List<ShippingDetailsDto>>(details);
            return result;
        }
    }
}