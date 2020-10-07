using MediatR;

namespace Gupy.Business.Commands.DeletePhoto
{
    public class DeletePhotoCommand : IRequest
    {
        public string FileName { get; set; }
    }
}