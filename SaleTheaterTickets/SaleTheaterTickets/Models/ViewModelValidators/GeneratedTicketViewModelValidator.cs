using FluentValidation;
using System;

namespace SaleTheaterTickets.Models.ViewModelValidators
{
    public class GeneratedTicketViewModelValidator : AbstractValidator<GeneratedTicketViewModel>
    {
        public GeneratedTicketViewModelValidator()
        {
            //RuleFor(x => x.CustomerName)
            //    .NotEmpty().WithMessage("Digite o nome do cliente")
            //    .Matches("/ ^[a-zA-Z çÇÁáÉéÍíÓóÚúÃã']+$/i").WithMessage("Nome aceita apenas de A-Z");
            RuleFor(x => x.Seat)
                .NotEmpty().WithMessage("Escolha a poltrona");
        }
    }
}
