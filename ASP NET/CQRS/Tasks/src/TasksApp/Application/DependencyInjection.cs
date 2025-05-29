using Application.UseCases.User.Handlers;
using Application.UseCases.User.Validators;
using Application.Utils.Mediator;
using Domain.Utils;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection 
    {

        public static void AddApplication(this IServiceCollection services)
        {

            services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
            services.AddFluentValidationAutoValidation();

            services.AddScoped<IMediator, Mediator>();

            //User - Commands
            services.AddScoped<CreateUserCommandHandler>();

        }

    }
}
