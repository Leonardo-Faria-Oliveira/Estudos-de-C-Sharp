using Domain.Utils;

namespace Domain.Adapters.Requests.User
{
    public record GetUsersRequest(
        int Take = 10,
        int Skip = 0,
        string CreatedAtOrderBy = "ASC",
        string? Search = null,
        Filters? Filters = null
    );
}
