﻿using Domain.Adapters.Responses;

namespace Domain.Adapters.Requests
{
    public interface IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

    }
}
