﻿namespace BiblioASPNet.Application.Models
{
    public class ResponseModel<T>
    {

        public T? Data { get; set; }

        public string Message { get; set; } = string.Empty;



    }
}
