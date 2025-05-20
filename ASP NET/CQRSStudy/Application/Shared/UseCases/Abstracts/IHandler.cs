namespace Application.Shared.UseCases.Abstracts
{
    public interface IHandler<TCommand, TResponse>
        where TCommand : ICommand
        where TResponse : IResponse
    {

        Task<TResponse> HandleAsync(TCommand command);

    }
}
