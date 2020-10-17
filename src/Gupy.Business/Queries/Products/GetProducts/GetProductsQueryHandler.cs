using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Business.Specifications;
using Gupy.Business.Specifications.Products;
using Gupy.Core.Common;
using Gupy.Core.Dtos;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Queries.Products.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IProductRepository productRepository, ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            Specification<Domain.Product> specification = null;

            if (request.Available != null)
            {
                specification = new ProductAvailableSpecification(request.Available.Value);
            }

            if (request.HasPromotion != null)
            {
                var spec = new ProductHasPromotionSpecification(request.HasPromotion.Value);
                specification = specification != null ? specification.And(spec) : spec;
            }

            if (request.CategoryId != null)
            {
                if (!await _categoryRepository.CategoryExists(request.CategoryId.Value))
                {
                    throw new NotFoundException(nameof(request.CategoryId),
                        $"Category with id ({request.CategoryId}) does not exist");
                }

                var spec = new ProductInCategorySpecification(request.CategoryId.Value);
                specification = specification != null ? specification.And(spec) : spec;
            }

            var products = await _productRepository.ListAsync(specification);

            var response = _mapper.Map<List<ProductDto>>(products);
            return response;
        }
    }
}