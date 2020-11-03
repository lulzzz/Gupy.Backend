using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Business.Commands.Photos;
using Gupy.Core.Dtos;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Common;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Commands.Products
{
    public class UpdateProductCommand : IRequest<ProductDto>
    {
        public ProductDto ProductDto { get; set; }
        public IFile Photo { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository,
            IMediator mediator, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mediator = mediator;
            _mapper = mapper;
        }


        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productDto = request.ProductDto;
            var product = await _productRepository.GetAsync(productDto.Id);
            if (product == null)
            {
                throw new NotValidException(nameof(productDto.Id),
                    $"Product with such id ({productDto.Id}) does not exist!");
            }

            if (!await _categoryRepository.CategoryExists(productDto.CategoryId))
            {
                throw new NotValidException(nameof(productDto.Id),
                    $"Category with id ({productDto.CategoryId} does not exist)");
            }

            if (request.Photo != null)
            {
                if (!string.IsNullOrEmpty(product.Photo))
                {
                    await _mediator.Send(new DeletePhotoCommand {FileName = product.Photo});
                }

                var fileName = await _mediator.Send(new UploadPhotoCommand {Photo = request.Photo});
                product.Photo = fileName;
            }

            _mapper.Map(productDto, product);
            await _productRepository.UnitOfWork.SaveChangesAsync();

            var updatedProductDto = _mapper.Map<ProductDto>(product);
            return updatedProductDto;
        }
    }
}