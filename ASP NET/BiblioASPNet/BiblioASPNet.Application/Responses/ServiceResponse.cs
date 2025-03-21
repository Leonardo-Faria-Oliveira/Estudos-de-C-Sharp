using System.Net;

namespace BiblioASPNet.Application.Responses
{
    public record ServiceResponse(

        HttpStatusCode StatusCode,

        string? Message,

        object? Content

    );


}
