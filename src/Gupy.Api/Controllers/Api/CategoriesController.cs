using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Api.Helpers;
using Gupy.Api.Models.Category;
using Gupy.Business.Commands.Categories;
using Gupy.Business.Queries.Categories;
using Gupy.Core.Dtos;
using HybridModelBinding;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gupy.Api.Controllers.Api
{
    public class CategoriesController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoriesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{categoryId:min(1)}")]
        public async Task<ActionResult<CategoryDto>> GetCategory([FromHybrid] GetCategoryByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories([FromHybrid] GetCategoriesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory([FromForm] CreateCategoryModel categoryModel)
        {
            var result = await _mediator.Send(new CreateCategoryCommand
            {
                Name = categoryModel.Name,
                Photo = categoryModel.Photo != null ? new FileAdapter(categoryModel.Photo) : null
            });

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<CategoryDto>> UpdateCategory([FromForm] UpdateCategoryModel categoryModel)
        {
            var result = await _mediator.Send(new UpdateCategoryCommand
            {
                CategoryDto = _mapper.Map<CategoryDto>(categoryModel),
                Photo = categoryModel.Photo != null ? new FileAdapter(categoryModel.Photo) : null
            });
            return Ok(result);
        }

        [HttpDelete("{categoryId:min(1)}")]
        public async Task<ActionResult> DeleteCategory([FromHybrid] DeleteCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}