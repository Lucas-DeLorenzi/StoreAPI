using MediatR;
using Store.Application.DTOs;
using Store.Domain.Common;
using Store.Domain.Entities;

namespace Store.Application.Features.Categories.Queries
{
    public class GetAllCategoriesQuery : IRequest<ServiceResponse<IEnumerable<CategoryDto>>>
    {
    }
}
