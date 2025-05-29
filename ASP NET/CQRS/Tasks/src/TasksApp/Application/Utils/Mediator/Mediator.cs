using Application.UseCases.User.Commands;
using Application.UseCases.User.Handlers;
using Domain.Adapters.Requests;
using Domain.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Utils.Mediator
{
    public class Mediator : IMediator
    {

        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<BaseResponse> Send<BaseResponse>(IRequest<BaseResponse> request, CancellationToken cancellationToken)
        {
            switch (request)
            {
                case CreateUserCommand command:
                    var createHandler = _serviceProvider.GetRequiredService<CreateUserCommandHandler>();
                    return (BaseResponse)(object)(await createHandler.Handle(command, cancellationToken));

                default:
                    throw new InvalidOperationException("Handler não encontrado para a requisição.");
            }
        }
    }
}
