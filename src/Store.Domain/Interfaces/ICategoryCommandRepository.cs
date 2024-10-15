using Store.Domain.Entities;

namespace Store.Domain.Interfaces
{
    public interface ICategoryCommandRepository
    {
        Task CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int categoryId);
    }
}
