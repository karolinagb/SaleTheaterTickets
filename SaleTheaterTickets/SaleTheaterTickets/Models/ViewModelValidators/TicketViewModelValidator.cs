using FluentValidation;
using System;

namespace SaleTheaterTickets.Models.ViewModelValidators
{
    public class TicketViewModelValidator : AbstractValidator<TicketViewModel>
    {
        public TicketViewModelValidator()
        {
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Digite o preço")
                .GreaterThan(0).WithMessage("O preço tem que ser maior que 0,00");
            RuleFor(x => x.QuantityOfSeats)
                .NotEmpty().WithMessage("Digite a quantidade de poltronas")
                .GreaterThanOrEqualTo(10).WithMessage("A quantidade de poltronas deve ser no mínimo 10");
            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Digite a Data")
                .Must(ValidDate).WithMessage("Data tem que ser maior ou igual a hoje");
            RuleFor(x => x.Schedule)
                .NotEmpty().WithMessage("Digite o horário");
            RuleFor(x => x.PieceId)
                .NotEmpty().WithMessage("Selecione a peça");
        }

        public static bool ValidDate(DateTime date)
        {
            if (date.Date >= DateTime.Now.Date)
            {
                return true;
            }

            return false;
        }
    }
}
