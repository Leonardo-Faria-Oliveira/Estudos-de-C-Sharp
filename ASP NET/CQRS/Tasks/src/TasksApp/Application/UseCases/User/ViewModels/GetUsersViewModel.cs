using Domain.Adapters.Responses;

namespace Application.UseCases.User.ViewModels
{
    public record GetUsersViewModel(
        ICollection<UserInfoViewModel> Users
    ) : TResponse;
}
