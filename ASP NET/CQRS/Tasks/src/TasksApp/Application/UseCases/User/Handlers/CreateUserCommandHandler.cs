using Application.UseCases.User.Commands;
using Application.UseCases.User.ViewModels;
using Domain.Adapters.Request;
using Domain.Repositories.User;
using Domain.Requests.User;

namespace Application.UseCases.User.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserInfoViewModel>
    {

        private readonly IUserWriteRepository _writeRepository;

        public CreateUserCommandHandler(IUserWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<UserInfoViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
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

            return new UserInfoViewModel();

        }
    }
}
