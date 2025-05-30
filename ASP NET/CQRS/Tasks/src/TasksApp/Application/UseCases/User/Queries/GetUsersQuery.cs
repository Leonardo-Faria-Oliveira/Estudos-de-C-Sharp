using Application.UseCases.User.ViewModels;
using Domain.Adapters.Requests;
using Domain.Adapters.Responses;
using Domain.Utils;

namespace Application.UseCases.User.Queries
{
    public record GetUsersQuery : IRequest<BaseResponse<GetUsersViewModel>>
    {
        public int Take { get; set; } = 10;
        public int Skip { get; set; } = 0;
        public string CreatedAtOrderBy { get; set; } = "ASC";
        public string? Search { get; set; } = null;
        public Filters? Filters { get; set; } = null;
    }
}
