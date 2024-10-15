using MediatR;
using Store.Application.DTOs;
using Store.Domain.Common;

namespace Store.Application.Features.Products.Queries
{
    public class GetProductByIdQuery : IRequest<ServiceResponse<ProductWithCategoryDTO>>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
