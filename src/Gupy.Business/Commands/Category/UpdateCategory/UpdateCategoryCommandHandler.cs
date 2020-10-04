using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Business.Commands.Photo.DeletePhoto;
using Gupy.Business.Commands.Photo.UploadPhoto;
using Gupy.Core.Dtos;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMediator mediator, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var updatedCategory = _mapper.Map<Domain.Category>(request.CategoryDto);
            var category = await _categoryRepository.GetCategoryWithPhotoAsync(updatedCategory.Id);
            if (category == null)
            {
                throw new NotFoundException(nameof(updatedCategory.Id),
                    $"Category with id ({updatedCategory.Id}) does not exist");
            }

            if (!await _categoryRepository.CategoryIsUnique(updatedCategory.Id, updatedCategory.Name))
            {
                throw new NotValidException(nameof(category.Name),
                    $"Category with such name ({updatedCategory.Name}) already exists");
            }

            if (request.Photo != null)
            {
                var oldPhoto = category.Photo;
                if (oldPhoto != null)
                {
                    await _mediator.Send(new DeletePhotoCommand {FileName = oldPhoto.FileName});
                }

                var fileName = await _mediator.Send(new UploadPhotoCommand {Photo = request.Photo});
                category.Photo = new Domain.Photo {FileName = fileName};
            }

            _mapper.Map(updatedCategory, category);
            await _categoryRepository.UnitOfWork.SaveChangesAsync();

            var result = _mapper.Map<CategoryDto>(category);
            return result;
        }
    }
}