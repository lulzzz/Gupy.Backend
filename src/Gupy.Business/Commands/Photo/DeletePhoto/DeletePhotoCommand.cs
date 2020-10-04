using MediatR;

namespace Gupy.Business.Commands.Photo.DeletePhoto
{
    public class DeletePhotoCommand : IRequest
    {
        public string FileName { get; set; }
    }
}