namespace Scopes.Services.Lifetime
{
    public class Operation : ITransient, IScoped, ISingleton
    {
        public string OperationId { get; }

        public Operation()
        {
            OperationId = Guid.NewGuid().ToString();
        }
    }
}
