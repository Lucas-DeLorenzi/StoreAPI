using MediatR;
using Store.Application.DTOs;
using Store.Domain.Common;
using Store.Domain.Entities;

namespace Store.Application.Features.Categories.Queries
{
    public class GetCategoryByIdQuery : IRequest<ServiceResponse<CategoryDto>>
    {
        public int Id { get; set; }
        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
