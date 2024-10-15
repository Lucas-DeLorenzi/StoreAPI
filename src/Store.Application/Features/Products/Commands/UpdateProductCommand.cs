using MediatR;
using Store.Application.DTOs;
using Store.Domain.Common;
using Store.Domain.Entities;

namespace Store.Application.Features.Products.Commands
{
    public class UpdateProductCommand : IRequest<ServiceResponse<ProductDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
