using System.Threading;
using System.Threading.Tasks;
using Gupy.Business.Commands.Photo.DeletePhoto;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Commands.Category.DeleteCategory
{
    public class DeleteCategoryCommandHandler : AsyncRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMediator _mediator;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMediator mediator)
        {
            _categoryRepository = categoryRepository;
            _mediator = mediator;
        }

        protected override async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryWithPhotoAsync(request.CategoryId);
            if (category == null)
            {
                throw new NotFoundException(nameof(request.CategoryId),
                    $"Product with id ({request.CategoryId}) does not exist");
            }

            if (category.Photo != null)
            {
                await _mediator.Send(new DeletePhotoCommand
                {
                    FileName = category.Photo.FileName
                });
            }

            _categoryRepository.Remove(category);
            await _categoryRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}