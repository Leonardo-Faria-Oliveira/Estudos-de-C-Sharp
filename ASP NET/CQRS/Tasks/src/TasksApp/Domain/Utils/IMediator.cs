using Domain.Adapters.Requests;

namespace Domain.Utils
{
    public interface IMediator
    {

        Task<BaseResponse> Send<BaseResponse>(IRequest<BaseResponse> request, CancellationToken cancellationToken);

    }
}
