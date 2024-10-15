using MediatR;
using Store.Application.Services.Interfaces;
using Store.Domain.Common;

namespace Store.Application.Features.Categories.Commands.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ServiceResponse<Unit>>
    {
        private readonly ICategoryService _categoryService;

        public DeleteCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<ServiceResponse<Unit>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _categoryService.DeleteCategoryAsync(request.Id);
            return result;
        }
    }
}
