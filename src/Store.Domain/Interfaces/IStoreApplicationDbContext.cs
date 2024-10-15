using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;

namespace Store.Domain.Interfaces
{
    public interface IStoreApplicationDbContext
    {
        #region DbSets
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        #endregion

        #region SaveChanges
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        #endregion
    }
}
