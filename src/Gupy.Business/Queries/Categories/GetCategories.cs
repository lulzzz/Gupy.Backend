using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Business.Specifications.Categories;
using Gupy.Core.Common;
using Gupy.Core.Dtos;
using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;
using MediatR;

namespace Gupy.Business.Queries.Categories
{
    public class GetCategoriesQuery : IRequest<List<CategoryDto>>
    {
        public bool? HasProducts { get; set; }
    }

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
            var specifications = new List<Specification<Category>>();
            if (request.HasProducts != null)
            {
                specifications.Add(new CategoryHasProductsSpecification(request.HasProducts.Value));
            }

            var categories = await _categoryRepository.ListAsync(specifications: specifications.ToArray());

            var result = _mapper.Map<List<CategoryDto>>(categories);
            return result;
        }
    }
}