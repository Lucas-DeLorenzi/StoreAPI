using MediatR;
using Store.Application.DTOs;
using Store.Domain.Common;
using Store.Domain.Entities;

namespace Store.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ServiceResponse<CategoryDto>> CreateCategoryAsync(Category category);
        Task<ServiceResponse<CategoryDto>> UpdateCategoryAsync(Category category);
        Task<ServiceResponse<Unit>> DeleteCategoryAsync(int id);
        Task<ServiceResponse<CategoryDto>> GetCategoryByIdAsync(int id);
        Task<ServiceResponse<IEnumerable<CategoryDto>>> GetAllCategoriesAsync();
    }
}
