using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Business.Commands.Photos.DeletePhoto;
using Gupy.Business.Commands.Photos.UploadPhoto;
using Gupy.Core.Dtos;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Commands.Categories.UpdateCategory
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
            var categoryDto = request.CategoryDto;
            var category = await _categoryRepository.GetAsync(categoryDto.Id);
            if (category == null)
            {
                throw new NotFoundException(nameof(categoryDto.Id),
                    $"Category with id ({categoryDto.Id}) does not exist");
            }

            if (!await _categoryRepository.CategoryIsUnique(categoryDto.Id, categoryDto.Name))
            {
                throw new NotValidException(nameof(category.Name),
                    $"Category with such name ({categoryDto.Name}) already exists");
            }

            if (request.Photo != null)
            {
                if (!string.IsNullOrEmpty(category.Photo))
                {
                    await _mediator.Send(new DeletePhotoCommand {FileName = category.Photo});
                }

                var fileName = await _mediator.Send(new UploadPhotoCommand {Photo = request.Photo});
                category.Photo = fileName;
            }

            _mapper.Map(categoryDto, category);
            await _categoryRepository.UnitOfWork.SaveChangesAsync();

            var result = _mapper.Map<CategoryDto>(category);
            return result;
        }
    }
}