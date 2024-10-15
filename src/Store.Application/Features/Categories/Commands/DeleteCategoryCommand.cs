using MediatR;
using Store.Domain.Common;

namespace Store.Application.Features.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest<ServiceResponse<Unit>>
    {
        public int Id { get; set; }
        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
