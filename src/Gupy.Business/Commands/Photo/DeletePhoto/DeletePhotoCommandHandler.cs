using System.Threading;
using System.Threading.Tasks;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Common;
using MediatR;

namespace Gupy.Business.Commands.DeletePhoto
{
    public class DeletePhotoCommandHandler : AsyncRequestHandler<DeletePhotoCommand>
    {
        private readonly IPhotoStorage _photoStorage;

        public DeletePhotoCommandHandler(IPhotoStorage photoStorage)
        {
            _photoStorage = photoStorage;
        }

        protected override async Task Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
        {
            var result = await _photoStorage.DeletePhotoAsync(request.FileName);
            if (!result)
            {
                throw new NotFoundException(nameof(request.FileName), $"Photo {request.FileName} does not exist");
            }
        }
    }
}