namespace Application.Exceptions
{
    public abstract class BaseException : SystemException
    {
        public virtual int StatusCode { get; }

        public abstract string GetError();

    }
}

