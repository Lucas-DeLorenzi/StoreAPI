using AutoMapper;
using MediatR;
using Store.Application.DTOs;
using Store.Application.Services.Interfaces;
using Store.Domain.Common;
using Store.Domain.Entities;

namespace Store.Application.Features.Products.Commands.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ServiceResponse<ProductDto>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            await _productService.CreateProductAsync(product);
            var result = await _productService.CreateProductAsync(product);
            return result;
        }
    }
}
