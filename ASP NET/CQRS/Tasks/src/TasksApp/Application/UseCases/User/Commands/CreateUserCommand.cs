using Application.UseCases.User.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Adapters.Requests;
using Domain.Adapters.Responses;

namespace Application.UseCases.User.Commands
{
    public record CreateUserCommand : IRequest<BaseResponse<UserInfoViewModel>>
    {

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

    }
}
