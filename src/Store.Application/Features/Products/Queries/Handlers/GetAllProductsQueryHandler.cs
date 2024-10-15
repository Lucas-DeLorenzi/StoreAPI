using MediatR;
using Store.Application.DTOs;
using Store.Application.Services.Interfaces;
using Store.Domain.Common;

namespace Store.Application.Features.Products.Queries.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ServiceResponse<IEnumerable<ProductDto>>>
    {
        private readonly IProductService _productService;

        public GetAllProductsQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ServiceResponse<IEnumerable<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetAllProductsAsync();
        }
    }
}
