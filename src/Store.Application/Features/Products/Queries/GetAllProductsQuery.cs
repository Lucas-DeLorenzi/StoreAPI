using MediatR;
using Store.Application.DTOs;
using Store.Domain.Common;

namespace Store.Application.Features.Products.Queries
{
    public class GetAllProductsQuery : IRequest<ServiceResponse<IEnumerable<ProductDto>>>
    {
    }
}
