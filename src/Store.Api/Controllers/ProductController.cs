using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOs;
using Store.Application.Features.Products.Commands;
using Store.Application.Features.Products.Queries;
using Store.Application.Services.Interfaces;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMediator _mediator;

        public ProductController(IProductService productService, IMediator mediator)
        {
            _productService = productService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var response = await _productService.GetAllProductsAsync();
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Data);
        }

        [HttpGet("byCategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProductsByCategory(int categoryId)
        {
            var response = await _productService.GetAllProductsByCategoryAsync(categoryId);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            if (response.Data == null || !response.Data.Any())
            {
                return NotFound($"No products found for category id {categoryId}");
            }

            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductWithCategoryDTO>> GetProductById(int id)
        {
            var response = await _productService.GetProductByIdAsync(id);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }

            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] CreateProductCommand command)
        {
            var response = await _mediator.Send(command);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return CreatedAtAction(nameof(GetProductById), new { id = response.Data.Id }, response.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Product ID mismatch");
            }

            var response = await _mediator.Send(command);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _mediator.Send(new DeleteProductCommand(id));
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return NoContent();
        }
    }
}
