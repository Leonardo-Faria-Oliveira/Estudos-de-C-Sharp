using Domain.Adapters.Requests.User;
using Domain.Entities;

namespace Domain.Repositories.User
{
    public interface IUserWriteRepository
    {

        Task CreateUser(CreateUserRequest user);

    }
}
