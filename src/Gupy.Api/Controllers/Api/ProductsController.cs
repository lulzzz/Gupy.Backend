using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Api.Helpers;
using Gupy.Api.Models.Product;
using Gupy.Business.Commands.Products;
using Gupy.Business.Queries.Products;
using Gupy.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gupy.Api.Controllers.Api
{
    public class ProductsController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("{id:min(1)}")]
        public async Task<ActionResult<ProductDto>> GetProduct([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery {ProductId = id});
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts([FromQuery] int? categoryId,
            [FromQuery] bool? available, [FromQuery] bool? hasPromotion)
        {
            var result = await _mediator.Send(
                new GetProductsQuery
                {
                    CategoryId = categoryId,
                    Available = available,
                    HasPromotion = hasPromotion
                });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromForm] CreateProductModel productModel)
        {
            var result = await _mediator.Send(new CreateProductCommand
            {
                ProductDto = _mapper.Map<ProductDto>(productModel),
                Photo = productModel.Photo != null ? new FileAdapter(productModel.Photo) : null
            });

            return CreatedAtAction(nameof(GetProduct), new {id = result.Id}, result);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDto>> UpdateProduct([FromForm] UpdateProductModel productModel)
        {
            var result = await _mediator.Send(new UpdateProductCommand
            {
                ProductDto = _mapper.Map<ProductDto>(productModel),
                Photo = productModel.Photo != null ? new FileAdapter(productModel.Photo) : null
            });

            return Ok(result);
        }

        [HttpDelete("{id:min(1)}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand
            {
                ProductId = id
            });
            return Ok(result);
        }
    }
}