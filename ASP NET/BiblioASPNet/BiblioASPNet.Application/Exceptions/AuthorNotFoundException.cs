
using System.Net;

namespace BiblioASPNet.Application.Exceptions
{
    public class AuthorNotFoundException : BaseException
    {
        public override int StatusCode => (int)HttpStatusCode.NotFound;

        private readonly ICollection<string> _errors = [];

        public override ICollection<string> GetErrors()
        {
            return _errors;
        }

        public AuthorNotFoundException(List<string> errorMessages) : base(string.Empty)
        {
            _errors = errorMessages;
        }
    }
}
