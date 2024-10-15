using MediatR;
using Store.Domain.Common;

namespace Store.Application.Features.Products.Commands
{
    public class DeleteProductCommand : IRequest<ServiceResponse<Unit>>
    {
        public int Id { get; set; }
        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
