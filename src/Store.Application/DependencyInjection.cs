using Microsoft.Extensions.DependencyInjection;
using Store.Application.Services.Interfaces;
using Store.Application.Services;
using Store.Application.Common.Mappings.Configuration;

namespace Store.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            #region MediatorServices
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            #endregion

            #region AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton(ProfilesConfiguration.MapProfiles());
            #endregion

            #region Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            #endregion

            return services;
        }

    }
}
