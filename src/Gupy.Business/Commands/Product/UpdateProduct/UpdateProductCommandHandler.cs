using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Business.Commands.Photo.DeletePhoto;
using Gupy.Business.Commands.Photo.UploadPhoto;
using Gupy.Core.Dtos;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMediator mediator, IMapper mapper)
        {
            _productRepository = productRepository;
            _mediator = mediator;
            _mapper = mapper;
        }


        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productDto = request.ProductDto;
            var product = await _productRepository.GetProductWithPhoto(productDto.Id);
            if (product == null)
            {
                throw new NotFoundException(nameof(productDto.Id),
                    $"Product with such id ({productDto.Id}) does not exist!");
            }

            if (request.Photo != null)
            {
                var oldPhoto = product.Photo;
                if (oldPhoto != null)
                {
                    await _mediator.Send(new DeletePhotoCommand {FileName = oldPhoto.FileName});
                }

                var fileName = await _mediator.Send(new UploadPhotoCommand {Photo = request.Photo});
                product.Photo = new Domain.Photo {FileName = fileName};
            }

            _mapper.Map(productDto, product);
            await _productRepository.UnitOfWork.SaveChangesAsync();

            var updatedProductDto = _mapper.Map<ProductDto>(product);
            return updatedProductDto;
        }
    }
}