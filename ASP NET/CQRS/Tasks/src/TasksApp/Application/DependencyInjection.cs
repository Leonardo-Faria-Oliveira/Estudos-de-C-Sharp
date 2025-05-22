using Application.UseCases.User.Handlers;
using Application.Utils.Mediator;
using Domain.Repositories.User;
using Domain.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {

        public static void AddApplication(this IServiceCollection services)
        {

            services.AddScoped<IMediator, Mediator>();

            //User - Commands
            services.AddScoped<CreateUserCommandHandler>();

        }

    }
}
