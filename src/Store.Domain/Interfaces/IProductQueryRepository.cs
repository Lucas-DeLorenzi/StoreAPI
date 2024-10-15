using Store.Domain.Entities;

namespace Store.Domain.Interfaces
{
    public interface IProductQueryRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);
    }
}
