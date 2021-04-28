using FluentValidation;
using System.Linq;
using System.Text.RegularExpressions;

namespace SaleTheaterTickets.Models.ViewModelValidators
{
    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Informe o e-mail")
                .EmailAddress().WithMessage("Digite um e-mail válido (Exemplo: exemplo@exemplo.com)");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Informe a senha")
                .Length(6, 20).WithMessage("Senha deve ter no mínimo 6 e no máximo 20 caractéres")
                .Must(RequireDigit).WithMessage("Senha deve ter pelo menos 1 número")
                .Must(RequiredLowerCase).WithMessage("Senha deve ter pelo menos 1 caracter minúsculo")
                .Must(RequireUppercase).WithMessage("Senha deve ter pelo menos 1 caracter maiúsculo")
                .Must(RequireNonAlphanumeric).WithMessage("Digite pelo menos 1 caracter especial (Exemplo: @ ! & * ...)");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirme a senha")
                .Equal(x => x.Password).WithMessage("Senhas não conferem");
        }

        private bool RequireDigit(string password)
        {
            if(password == null)
            {
                password = "";
            }
            if (password.Any(x => char.IsDigit(x)))
            {
                return true;
            }
            return false;
        }

        private bool RequiredLowerCase(string password)
        {
            if (password == null)
            {
                password = "";
            }
            if (password.Any(x => char.IsLower(x)))
            {
                return true;
            }
            return false;
        }

        private bool RequireUppercase(string password)
        {
            if (password == null)
            {
                password = "";
            }
            if (password.Any(x => char.IsUpper(x)))
            {
                return true;
            }
            return false;
        }

        private bool RequireNonAlphanumeric(string password)
        {
            //if (password.Any(x => char.IsSymbol(x)))
            //{
            //    return true;
            //}
            //return false;
            if (password == null)
            {
                password = "";
            }
            if (Regex.IsMatch(password, "(?=.*[@#$%^&+=!])"))
            {
                return true;
            }
            return false;
        }
    }
}