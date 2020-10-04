using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Business.Specifications;
using Gupy.Core.Common;
using Gupy.Core.Dtos;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Queries.Category.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            Specification<Domain.Category> specification = null;
            if (request.HasProducts != null)
            {
                specification = new CategoryHasProductsSpecification(request.HasProducts.Value);
            }

            var categories = await _categoryRepository.ListAsync(specification);

            var result = _mapper.Map<List<CategoryDto>>(categories);
            return result;
        }
    }
}