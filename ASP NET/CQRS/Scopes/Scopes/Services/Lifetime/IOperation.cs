namespace Scopes.Services.Lifetime
{
    public interface IOperation
    {
        string OperationId { get; }
    }

    public interface IScoped : IOperation { }
    public interface ISingleton : IOperation { }
    public interface ITransient : IOperation { }
}
