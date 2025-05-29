using Domain.Adapters.Responses;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace Application.UseCases.User.ViewModels
{
    public record UserInfoViewModel(

    string Name,

    string Surname,

    string Email

    ) : TResponse;
}
