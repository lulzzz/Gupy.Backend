using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Api.Helpers;
using Gupy.Api.Models.Product;
using Gupy.Business.Commands.Products;
using Gupy.Business.Queries.Products;
using Gupy.Core.Dtos;
using HybridModelBinding;
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

        [HttpGet("{productId:min(1)}")]
        public async Task<ActionResult<ProductDto>> GetProduct([FromHybrid] GetProductByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts([FromHybrid] GetProductsQuery query)
        {
            var result = await _mediator.Send(query);
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

            return Ok(result);
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

        [HttpDelete("{productId:min(1)}")]
        public async Task<ActionResult> DeleteProduct([FromHybrid] DeleteProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}