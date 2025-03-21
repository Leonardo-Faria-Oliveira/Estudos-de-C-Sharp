namespace BiblioASPNet.Application.Exceptions
{
    public abstract class BaseException(string errorMessage) : SystemException(errorMessage)
    {

        public abstract int StatusCode { get; }

        public abstract ICollection<string> GetErrors();

    }
}
