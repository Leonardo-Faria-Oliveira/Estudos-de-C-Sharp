using Domain.Adapters.Requests.User;
using Domain.Adapters.Responses;
using Domain.Adapters.Responses.User;

namespace Domain.Repositories.User
{
    public interface IUserReadRepository
    {

        Task<ICollection<ShortUserResponse>> GetUsers(GetUsersRequest request);

    }
}
 