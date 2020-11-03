using System.Threading;
using System.Threading.Tasks;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Common;
using Gupy.Core.Settings;
using MediatR;
using Microsoft.Extensions.Options;

namespace Gupy.Business.Commands.Photos
{
    public class UploadPhotoCommand : IRequest<string>
    {
        public IFile Photo { get; set; }
    }
    
    public class UploadPhotoCommandHandler : IRequestHandler<UploadPhotoCommand, string>
    {
        private readonly IPhotoStorage _photoStorage;
        private readonly PhotoSettings _photoSettings;

        public UploadPhotoCommandHandler(IPhotoStorage photoStorage, IOptions<PhotoSettings> photoSettingsOptions)
        {
            _photoStorage = photoStorage;
            _photoSettings = photoSettingsOptions.Value;
        }

        public async Task<string> Handle(UploadPhotoCommand request, CancellationToken cancellationToken)
        {
            var photo = request.Photo;
            
            ValidatePhoto(photo);

            var fileName = await _photoStorage.StorePhotoAsync(photo);
            return fileName;
        }

        private void ValidatePhoto(IFile photo)
        {
            if (photo.Length > _photoSettings.MaxBytes || photo.Length <= 0)
            {
                throw new NotValidException(nameof(photo.Length),
                    $"Photo size should be greater than 0 and less than {_photoSettings.MaxBytes / 1024 / 1024} MB");
            }

            if (!_photoSettings.HasSupportedExtension(photo.FileName))
            {
                throw new NotValidException(nameof(photo.FileName), "Unsupported file extension!");
            }
        }
    }
}