using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Business.Commands.Photos.UploadPhoto;
using Gupy.Core.Dtos;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;
using MediatR;

namespace Gupy.Business.Commands.Products.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository,
            IMediator mediator, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.ProductDto);
            if (!await _categoryRepository.CategoryExists(product.CategoryId))
            {
                throw new NotValidException(nameof(product.CategoryId),
                    $"Category with such id ({product.CategoryId}) does not exist");
            }

            if (request.Photo != null)
            {
                var fileName = await _mediator.Send(new UploadPhotoCommand {Photo = request.Photo});
                product.Photo = fileName;
            }

            await _productRepository.AddAsync(product);
            await _productRepository.UnitOfWork.SaveChangesAsync();

            var createdProductDto = _mapper.Map<ProductDto>(product);
            return createdProductDto;
        }
    }
}