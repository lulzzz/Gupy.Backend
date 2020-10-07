using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Api.Helpers;
using Gupy.Api.Models.Category;
using Gupy.Business.Commands.CreateCategory;
using Gupy.Business.Commands.DeleteCategory;
using Gupy.Business.Commands.UpdateCategory;
using Gupy.Business.Queries.Category.GetCategories;
using Gupy.Business.Queries.Category.GetCategoryById;
using Gupy.Core.Dtos;
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

        [HttpGet("{id:min(1)}")]
        public async Task<ActionResult<CategoryDto>> GetCategory([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery {CategoryId = id});
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories([FromQuery] bool? hasProducts)
        {
            var result = await _mediator.Send(new GetCategoriesQuery {HasProducts = hasProducts});
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

            return CreatedAtAction(nameof(GetCategory), new {id = result.Id}, result);
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

        [HttpDelete("{id:min(1)}")]
        public async Task<ActionResult> DeleteCategory([FromRoute] int id)
        {
            await _mediator.Send(new DeleteCategoryCommand {CategoryId = id});
            return Ok();
        }
    }
}