using System.Threading;
using System.Threading.Tasks;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Commands.Details.DeleteDetails
{
    public class DeleteDetailsCommandHandler : AsyncRequestHandler<DeleteDetailsCommand>
    {
        private readonly IShippingDetailsRepository _detailsRepository;

        public DeleteDetailsCommandHandler(IShippingDetailsRepository detailsRepository)
        {
            _detailsRepository = detailsRepository;
        }

        protected override async Task Handle(DeleteDetailsCommand request, CancellationToken cancellationToken)
        {
            var details = await _detailsRepository.GetAsync(request.ShippingDetailsId);
            if (details == null)
            {
                throw new NotFoundException(nameof(request.ShippingDetailsId),
                    $"Shipping Details with id ({request.ShippingDetailsId}) doesn't exist");
            }

            _detailsRepository.Remove(details);
            await _detailsRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}