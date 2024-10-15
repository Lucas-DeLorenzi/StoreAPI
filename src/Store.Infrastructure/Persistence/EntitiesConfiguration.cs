using Microsoft.EntityFrameworkCore;
using Store.Infrastructure.Persistence.Configurations;

namespace Store.Infrastructure.Persistence
{
    public static class EntitiesConfiguration
    {
        public static void ApplyEntityConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
}
