using System.Threading;
using System.Threading.Tasks;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Common;
using MediatR;

namespace Gupy.Business.Commands.Photos
{
    public class DeletePhotoCommand : IRequest
    {
        public string FileName { get; set; }
    }
    
    public class DeletePhotoCommandHandler : AsyncRequestHandler<DeletePhotoCommand>
    {
        private readonly IPhotoStorage _photoStorage;

        public DeletePhotoCommandHandler(IPhotoStorage photoStorage)
        {
            _photoStorage = photoStorage;
        }

        protected override async Task Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
        {
            await _photoStorage.DeletePhotoAsync(request.FileName);
        }
    }
}