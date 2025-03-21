
using System.Net;

namespace BiblioASPNet.Application.Exceptions
{
    public class ValidationErrorException : BaseException
    {


        public override int StatusCode => (int)HttpStatusCode.BadRequest;

        private readonly ICollection<string> _errors = [];

        public ValidationErrorException(List<string> errorMessages) : base(string.Empty)
        {
            _errors = errorMessages;
        }

        public override ICollection<string> GetErrors()
        {

            return _errors;

        }
    }
}
