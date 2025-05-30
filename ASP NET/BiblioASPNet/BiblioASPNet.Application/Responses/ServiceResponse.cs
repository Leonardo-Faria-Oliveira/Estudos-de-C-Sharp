﻿using System.Net;

namespace BiblioASPNet.Application.Responses
{
    public record ServiceResponse(

        HttpStatusCode StatusCode,

        ICollection<string>? Message,

        object? Content

    );


}
