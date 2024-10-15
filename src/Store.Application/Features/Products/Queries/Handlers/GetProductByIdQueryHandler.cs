using MediatR;
using Store.Application.DTOs;
using Store.Application.Services.Interfaces;
using Store.Domain.Common;

namespace Store.Application.Features.Products.Queries.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ServiceResponse<ProductWithCategoryDTO>>
    {
        private readonly IProductService _productService;

        public GetProductByIdQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ServiceResponse<ProductWithCategoryDTO>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetProductByIdAsync(request.Id);
        }
    }
}
