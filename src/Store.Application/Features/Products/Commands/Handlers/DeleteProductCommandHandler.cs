using MediatR;
using Store.Application.Services.Interfaces;
using Store.Domain.Common;

namespace Store.Application.Features.Products.Commands.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ServiceResponse<Unit>>
    {
        private readonly IProductService _productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ServiceResponse<Unit>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var result =  await _productService.DeleteProductAsync(request.Id);
            return result;
        }
    }
}
