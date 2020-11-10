using System.Threading;
using System.Threading.Tasks;
using Gupy.Business.Commands.Photos;
using Gupy.Business.Specifications.Products;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Commands.Categories
{
    public class DeleteCategoryCommand : IRequest
    {
        public int CategoryId { get; set; }
    }

    public class DeleteCategoryCommandHandler : AsyncRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository,
            IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        protected override async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(request.CategoryId);
            if (category == null)
            {
                throw new NotFoundException(nameof(request.CategoryId),
                    $"Category with id ({request.CategoryId}) does not exist");
            }

            category.SoftDeleted = true;
            
            var products = await _productRepository.ListAsync(false, new ProductInCategorySpecification(category.Id));
            products.ForEach(p => p.SoftDeleted = true);

            await _categoryRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}