using Domain.Repositories.User;
using Infrastructure.Persistence;
using Infrastructure.Persistence.SQLServer.Config;
using Infrastructure.Persistence.SQLServer.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {

        public static void AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<IWriteDbConnection, SQLServerConnection>();
            services.AddScoped<IUserWriteRepository, UserRepository>();

        }

    }
}
