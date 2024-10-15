using MediatR;
using Store.Application.DTOs;
using Store.Domain.Common;

namespace Store.Application.Features.Products.Queries
{
    public class GetAllProductsByCategoryQuery : IRequest<ServiceResponse<IEnumerable<ProductDto>>>
    {
        public int CategoryId { get; set; }

        public GetAllProductsByCategoryQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
