using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Core.Dtos;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Queries.ShippingDetails.GetDetailsById
{
    public class GetDetailsByIdQueryHandler : IRequestHandler<GetDetailsByIdQuery, ShippingDetailsDto>
    {
        private readonly IShippingDetailsRepository _detailsRepository;
        private readonly IMapper _mapper;

        public GetDetailsByIdQueryHandler(IShippingDetailsRepository detailsRepository, IMapper mapper)
        {
            _detailsRepository = detailsRepository;
            _mapper = mapper;
        }


        public async Task<ShippingDetailsDto> Handle(GetDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var details = await _detailsRepository.GetAsync(request.ShippingDetailsId);
            if (details == null)
            {
                throw new NotFoundException(nameof(request.ShippingDetailsId),
                    $"Shipping Details with id ({request.ShippingDetailsId}) doesn't exist");
            }

            var result = _mapper.Map<ShippingDetailsDto>(details);
            return result;
        }
    }
}