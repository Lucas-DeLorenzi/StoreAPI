using Store.Domain.Entities;

namespace Store.Domain.Interfaces
{
    public interface ICategoryQueryRepository
    {
        Task<Category> GetByIdAsync(int categoryId);
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
