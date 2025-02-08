using CRUDByBlazorTemplate.Data.Context;
using CRUDByBlazorTemplate.Dtos;
using CRUDByBlazorTemplate.Mappers;
using CRUDByBlazorTemplate.Models;
using CRUDByBlazorTemplate.Repositories;
using CRUDByBlazorTemplate.Repository;
using CRUDByBlazorTemplate.Request;
using CRUDByBlazorTemplate.Response;
using CRUDByBlazorTemplate.Response.Post;
using CRUDByBlazorTemplate.Service;
using CRUDByBlazorTemplate.Services;

namespace CRUDByBlazorTemplate.Config
{
    public static class DependencyInjection
    {

        public static IServiceCollection ResolveDependecies(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBaseMapper<Category, CategoryDto, CategoryByIdResponse, CategoryResponse, CategoryRequest>, CategoryMapper>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IBaseMapper<Post, PostDto, PostByIdResponse, PostResponse, PostRequest>, PostMapper>();
            services.AddScoped<IPostService, PostService>();

            services.AddScoped<IUserRepository, UserRepository>();
            

            return services;
        }

    }
}
