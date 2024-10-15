using MediatR;
using Store.Application.DTOs;
using Store.Application.Services.Interfaces;
using Store.Domain.Common;

namespace Store.Application.Features.Products.Queries.Handlers
{
    internal class GetAllProductsByCategoryQueryHandler : IRequestHandler<GetAllProductsByCategoryQuery, ServiceResponse<IEnumerable<ProductDto>>>
    {
        private readonly IProductService _productService;

        public GetAllProductsByCategoryQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ServiceResponse<IEnumerable<ProductDto>>> Handle(GetAllProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetAllProductsByCategoryAsync(request.CategoryId);
        }

    }
}
