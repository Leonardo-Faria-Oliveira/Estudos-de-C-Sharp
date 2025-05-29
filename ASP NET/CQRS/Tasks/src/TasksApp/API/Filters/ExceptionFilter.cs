using Application.Exceptions;
using Domain.Adapters.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            if(context.Exception is BaseException)
            {
                HandleException(context);
            }

            ThrowInternalError(context);
        }


        private void HandleException(ExceptionContext context)
        {

            var exception = (BaseException)context.Exception;
            var errorResponse = new BaseResponse<object>(
                new ResponseInfo(
                    "Houve um erro",
                    exception.GetError(),
                    exception.StatusCode
                ),
                null
            );
            context.HttpContext.Response.StatusCode = exception.StatusCode;
            context.Result = new ObjectResult(errorResponse);

        }

        private void ThrowInternalError(ExceptionContext context)
        {
            var errorResponse = new BaseResponse<object>(
                new ResponseInfo(
                    "Houve um erro interno, contate o suporte",
                    null,
                    500
                ),
                null
            );
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        
        }
    }
}
