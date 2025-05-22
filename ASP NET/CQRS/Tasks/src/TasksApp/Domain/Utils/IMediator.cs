using Domain.Adapters.Request;

namespace Domain.Utils
{
    public interface IMediator
    {

        Task<BaseResponse> Send<BaseResponse>(IRequest<BaseResponse> request, CancellationToken cancellationToken);

    }
}
