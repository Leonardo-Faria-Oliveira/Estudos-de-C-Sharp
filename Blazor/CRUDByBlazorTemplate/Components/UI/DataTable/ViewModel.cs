﻿using CRUDByBlazorTemplate.Dtos;
using Microsoft.AspNetCore.Components;

namespace CRUDByBlazorTemplate.Components.UI.DataTable
{
    public class ViewModel<T> where T : class
    {

        public ViewModel(List<(string Header, string PropName)> headers,  List<T>? itens, int total, int take, ResultPageState resultPage, string? search, object? response) 
        {
            Headers = headers;
            Itens = itens;
            Total = total;
            Take = take;
            ResultPage = resultPage;
            Search = search;
            Response = response;
        }

        public List<(string Header, string PropName)> Headers { get; set; }

        public List<T>? Itens { get; set; }

        public int Total { get; set; }

        public int Take { get; set; }

        public ResultPageState ResultPage { get; set; }

        public string? Search { get; set; }

        public object? Response { get; set; }

    }
}