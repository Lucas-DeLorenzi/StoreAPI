using Microsoft.EntityFrameworkCore;
using Store.Domain.Common;
using Store.Domain.Entities;
using Store.Domain.Interfaces;

namespace Store.Infrastructure.Persistence
{
    public class StoreApplicationDbContext : DbContext, IStoreApplicationDbContext
    {
        public StoreApplicationDbContext(DbContextOptions<StoreApplicationDbContext> options)
            : base(options)
        {
        }

        #region DbSets
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        #endregion

        #region SaveChanges
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                var entries = ChangeTracker
                    .Entries()
                    .Where(e => e.Entity is AuditableEntity && (
                            e.State == EntityState.Added
                            || e.State == EntityState.Modified));

                foreach (var entityEntry in entries)
                {
                    if (entityEntry.State == EntityState.Added)
                    {
                        ((AuditableEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
                        ((AuditableEntity)entityEntry.Entity).IsActive = true;
                    }
                    else
                    {
                        Entry((AuditableEntity)entityEntry.Entity).Property(p => p.CreatedAt).IsModified = false;
                    }

                    ((AuditableEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;
                }

                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"An error occurred while saving changes: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred: {ex.Message}", ex);
            }
        }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyEntityConfigurations();
        }
    }
}


