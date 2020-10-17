using System.Threading;
using System.Threading.Tasks;
using Gupy.Business.Commands.Photos.DeletePhoto;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Commands.Categories.DeleteCategory
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
            var category = await _categoryRepository.GetAsync(request.CategoryId);
            if (category == null)
            {
                throw new NotFoundException(nameof(request.CategoryId),
                    $"Category with id ({request.CategoryId}) does not exist");
            }

            if (!string.IsNullOrEmpty(category.Photo))
            {
                await _mediator.Send(new DeletePhotoCommand
                {
                    FileName = category.Photo
                });
            }

            _categoryRepository.Remove(category);
            await _categoryRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}