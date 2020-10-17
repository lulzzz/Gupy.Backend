using MediatR;

namespace Gupy.Business.Commands.Photos.DeletePhoto
{
    public class DeletePhotoCommand : IRequest
    {
        public string FileName { get; set; }
    }
}