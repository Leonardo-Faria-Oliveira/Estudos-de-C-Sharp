using BiblioASPNet.Application.Exceptions;
using BiblioASPNet.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BiblioASPNet.Application.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            if(context.Exception is BaseException)
            {

                var exception = (BaseException)context.Exception;
                var errorResponse = new ServiceResponse
                (
                   (HttpStatusCode)exception.StatusCode,
                   null,
                   exception.GetErrors()
                );
                context.HttpContext.Response.StatusCode = exception.StatusCode;
                context.Result = new ObjectResult(errorResponse);

            }
            else
            {
                ThrowUnknowError(context);
            }

        }

        private void ThrowUnknowError(ExceptionContext context)
        {
            var errorResponse = new ServiceResponse
            (
               System.Net.HttpStatusCode.InternalServerError,
               null,
               "Houve um erro interno, contate o suporte"
            );

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Result = new ObjectResult(errorResponse);
        }
    }
}
