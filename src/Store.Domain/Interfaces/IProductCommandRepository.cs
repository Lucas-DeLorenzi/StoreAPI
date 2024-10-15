using Store.Domain.Entities;

namespace Store.Domain.Interfaces
{
    public interface IProductCommandRepository
    {
        Task CreateAsync(Product producto);
        Task UpdateAsync(Product producto);
        Task DeleteAsync(int id);
    }
}
