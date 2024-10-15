using MediatR;
using Store.Application.DTOs;
using Store.Domain.Common;

namespace Store.Application.Features.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<ServiceResponse<CategoryDto>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
