namespace Gupy.Business.Services
{
    // public class CategoryService : ICategoryService
    // {
    //     private readonly ICategoryRepository _categoryRepository;
    //     private readonly IPhotoService _photoService;
    //     private readonly IMapper _mapper;
    //
    //     public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IPhotoService photoService)
    //     {
    //         _categoryRepository = categoryRepository;
    //         _mapper = mapper;
    //         _photoService = photoService;
    //     }
    //
    //
    //     public async Task<IEnumerable<CategoryDto>> GetCategories()
    //     {
    //         var categories = await _categoryRepository.GetCategoriesWithPhotos();
    //         var categoriesDtos = _mapper.Map<List<CategoryDto>>(categories);
    //
    //         return categoriesDtos;
    //     }
    //
    //     public async Task<CategoryDto> GetCategory(int id)
    //     {
    //         var category = await _categoryRepository.GetCategoryWithPhoto(id);
    //         if (category == null)
    //         {
    //             var error = new Error(nameof(id), "Category with such id does not exist");
    //             throw new NotFoundException(error);
    //         }
    //
    //         var categoryDto = _mapper.Map<CategoryDto>(category);
    //         return categoryDto;
    //     }
    //
    //     public async Task<CategoryDto> CreateCategory(CategoryDto categoryDto, IFile categoryPhoto = null)
    //     {
    //         if (!await _categoryRepository.CategoryIsUnique(categoryDto.Name))
    //         {
    //             var error = new Error(nameof(categoryDto.Name), "Category with such name already exists!");
    //             throw new NotValidException(error);
    //         }
    //
    //         var category = _mapper.Map<Category>(categoryDto);
    //         _categoryRepository.Add(category);
    //
    //         if (categoryPhoto != null)
    //         {
    //             var fileName = _photoService.UploadPhoto(categoryPhoto);
    //             category.Photo = new Photo {FileName = fileName};
    //         }
    //
    //         await _categoryRepository.UnitOfWork.SaveChangesAsync();
    //
    //         var resultDto = _mapper.Map<CategoryDto>(category);
    //         return resultDto;
    //     }
    //
    //     public CategoryDto UpdateCategory(CategoryDto categoryDto, IFile categoryPhoto = null)
    //     {
    //         var category = _categoryRepository.GetCategoryWithPhoto(categoryDto.Id);
    //         if (category == null)
    //         {
    //             var error = new Error(nameof(categoryDto.Id), "Category with such id does not exist!");
    //             throw new NotFoundException(error);
    //         }
    //
    //         // TODO: Check if duplicate category name is created 
    //
    //         _mapper.Map(categoryDto, category);
    //         if (categoryPhoto != null)
    //         {
    //             var oldPhoto = category.Photo;
    //             if (oldPhoto != null)
    //             {
    //                 _photoService.DeletePhoto(oldPhoto.FileName);
    //             }
    //
    //             var fileName = _photoService.UploadPhoto(categoryPhoto);
    //             category.Photo = new Photo {FileName = fileName};
    //         }
    //
    //         _categoryRepository.UnitOfWork.SaveChanges();
    //
    //         var updatedCategory = _mapper.Map<CategoryDto>(category);
    //         return updatedCategory;
    //     }
    //
    //     public void DeleteCategory(int id)
    //     {
    //         var category = _categoryRepository.GetCategoryWithPhoto(id);
    //         if (category == null)
    //         {
    //             var error = new Error(nameof(id), "Category with such id does not exist!");
    //             throw new NotFoundException(error);
    //         }
    //
    //         if (category.Photo != null)
    //         {
    //             _photoService.DeletePhoto(category.Photo.FileName);
    //         }
    //
    //         _categoryRepository.Remove(category);
    //         _categoryRepository.UnitOfWork.SaveChanges();
    //     }
    // }
}