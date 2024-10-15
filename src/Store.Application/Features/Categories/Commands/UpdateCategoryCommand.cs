using MediatR;
using Store.Application.DTOs;
using Store.Domain.Common;

namespace Store.Application.Features.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest<ServiceResponse<CategoryDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
