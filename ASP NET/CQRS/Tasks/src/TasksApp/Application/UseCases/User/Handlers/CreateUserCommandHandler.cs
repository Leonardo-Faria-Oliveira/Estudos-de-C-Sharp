using Application.UseCases.User.Commands;
using Application.UseCases.User.ViewModels;
using Domain.Adapters.Requests;
using Domain.Adapters.Requests.User;
using Domain.Adapters.Responses;
using Domain.Repositories.User;
using System.Net;

namespace Application.UseCases.User.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseResponse<UserInfoViewModel>>
    {

        private readonly IUserWriteRepository _writeRepository;

        public CreateUserCommandHandler(IUserWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<BaseResponse<UserInfoViewModel>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new CreateUserRequest(
                request.Name,
                request.Surname,
                request.Email,
                request.PasswordHash,
                request.Username,
                false
            );
              
            await _writeRepository.CreateUser(user);

            return new BaseResponse<UserInfoViewModel>(
                new ResponseInfo(
                    "Usuário Cadastrado com sucesso!",
                    null,
                    (int)HttpStatusCode.OK
                ),
                new UserInfoViewModel(
                    user.Name,
                    user.Surname,
                    user.Email
                )
            );

        }

    }
}
