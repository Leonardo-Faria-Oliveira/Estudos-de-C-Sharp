using BiblioASPNet.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BiblioASPNet.Application.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            if(context.Exception is BaseException)
            {

                var exception = (BaseException)context.Exception;
                //var errorMessage = new ResponseErrorJson { ErrorMessage = exception.GetErrors() };
                context.HttpContext.Response.StatusCode = exception.StatusCode;
                context.Result = new ObjectResult(exception.GetErrors());

            }
            else
            {
                ThrowUnknowError(context);
            }

        }

        private void ThrowUnknowError(ExceptionContext context)
        {
            //var errorMessage = new ResponseErrorJson { ErrorMessage = [context.Exception.Message] };

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Result = new ObjectResult("Houve um erro interno, contate o suporte");
        }
    }
}
