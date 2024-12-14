using CRUDByBlazorTemplate.Data.Context;
using CRUDByBlazorTemplate.Repository;

namespace CRUDByBlazorTemplate.Config
{
    public static class DependencyInjection
    {

        public static IServiceCollection ResolveDependecies(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();

            // Services
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }

    }
}
