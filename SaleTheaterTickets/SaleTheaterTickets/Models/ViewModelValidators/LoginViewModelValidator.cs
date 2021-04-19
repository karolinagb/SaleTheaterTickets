using FluentValidation;

namespace SaleTheaterTickets.Models.ViewModelValidators
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(X => X.Email)
                .NotEmpty().WithMessage("Informe o e-mail")
                .EmailAddress().WithMessage("Digite um e - mail válido(ana@gmail.com)");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Informe a senha");
        }
    }
}
