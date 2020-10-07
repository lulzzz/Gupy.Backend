using Gupy.Core.Interfaces.Common;
using MediatR;

namespace Gupy.Business.Commands.UploadPhoto
{
    public class UploadPhotoCommand : IRequest<string>
    {
        public IFile Photo { get; set; }
    }
}