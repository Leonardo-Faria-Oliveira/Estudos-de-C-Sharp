using Application.UseCases.User.Queries;
using Application.UseCases.User.ViewModels;
using Domain.Adapters.Requests;
using Domain.Adapters.Requests.User;
using Domain.Adapters.Responses;
using Domain.Repositories.User;
using System.Net;

namespace Application.UseCases.User.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, BaseResponse<GetUsersViewModel>>
    {

        private readonly IUserReadRepository _userReadRepository;

        public GetUsersQueryHandler(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }

        public async Task<BaseResponse<GetUsersViewModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {

            var getUsersRequest = new GetUsersRequest(         
                request.Take,
                request.Skip,
                request.CreatedAtOrderBy,
                request.Search,
                request.Filters
            );

            var users = await _userReadRepository.GetUsers(getUsersRequest);

            var getUsersViewModel = new GetUsersViewModel(
                users.Select(user => new UserInfoViewModel(
                    user.Name,
                    user.Email,
                    user.Surname
                )).ToList()
            );

            return new BaseResponse<GetUsersViewModel>
            (
                new ResponseInfo(
                    "Usuários listados com sucesso!",
                    null,
                    (int)HttpStatusCode.OK
                ),
                getUsersViewModel
            );

        }
    }
}
