using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Adapters.Requests.User
{
    public record CreateUserRequest(
        string Name,

        string Surname,

        string Email,

        string PasswordHash,

        string Username,

        bool IsActive
    );
}
