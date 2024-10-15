using MediatR;
using Store.Application.DTOs;
using Store.Domain.Common;

namespace Store.Application.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<ServiceResponse<ProductDto>>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
