using MediatR;
using Store.Application.DTOs;
using Store.Domain.Common;
using Store.Domain.Entities;

namespace Store.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResponse<ProductDto>> CreateProductAsync(Product product);
        Task<ServiceResponse<ProductDto>> UpdateProductAsync(Product product);
        Task<ServiceResponse<Unit>> DeleteProductAsync(int id);
        Task<ServiceResponse<ProductWithCategoryDTO>> GetProductByIdAsync(int id);
        Task<ServiceResponse<IEnumerable<ProductDto>>> GetAllProductsAsync();
        Task<ServiceResponse<IEnumerable<ProductDto>>> GetAllProductsByCategoryAsync(int categoryId);
    }
}
