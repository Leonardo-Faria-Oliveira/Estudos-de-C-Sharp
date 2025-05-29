using Application.UseCases.User.Commands;
using FluentValidation;

namespace Application.UseCases.User.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {

        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O email é necessário").WithErrorCode("400")
            .EmailAddress().WithMessage("Email inválido").WithErrorCode("400");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("O username é necessário").WithErrorCode("400")
                .MinimumLength(8).WithMessage("O username deve possuir pelo menos 6 caracteres").WithErrorCode("400");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome é necessário").WithErrorCode("400")
                .MinimumLength(2).WithMessage("O username deve possuir pelo menos 30 caracteres").WithErrorCode("400");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("O sobrenome é necessário").WithErrorCode("400")
                .MinimumLength(2).WithMessage("O username deve possuir pelo menos 2 caracteres").WithErrorCode("400");

        }

    }
}
