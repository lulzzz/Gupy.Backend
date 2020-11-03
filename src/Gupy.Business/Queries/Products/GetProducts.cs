using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Business.Specifications.Products;
using Gupy.Core.Common;
using Gupy.Core.Dtos;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;
using MediatR;

namespace Gupy.Business.Queries.Products
{
    public class GetProductsQuery : IRequest<List<ProductDto>>
    {
        public int? CategoryId { get; set; }
        public bool? Available { get; set; }
        public bool? HasPromotion { get; set; }
    }

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
            var specifications = new List<Specification<Product>>();

            if (request.Available != null)
            {
                specifications.Add(new ProductAvailableSpecification(request.Available.Value));
            }

            if (request.HasPromotion != null)
            {
                specifications.Add(new ProductHasPromotionSpecification(request.HasPromotion.Value));
            }

            if (request.CategoryId != null)
            {
                if (!await _categoryRepository.CategoryExists(request.CategoryId.Value))
                {
                    throw new NotFoundException(nameof(request.CategoryId),
                        $"Category with id ({request.CategoryId}) does not exist");
                }

                specifications.Add(new ProductInCategorySpecification(request.CategoryId.Value));
            }

            var products = await _productRepository.ListAsync(specifications: specifications.ToArray());

            var response = _mapper.Map<List<ProductDto>>(products);
            return response;
        }
    }
}