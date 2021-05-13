using FluentValidation;
using System;

namespace SaleTheaterTickets.Models.ViewModelValidators
{
    public class GeneratedTicketViewModelValidator : AbstractValidator<GeneratedTicketViewModel>
    {
        public GeneratedTicketViewModelValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Digite o nome do cliente");
            //    .Matches("/ ^[a-zA-Z çÇÁáÉéÍíÓóÚúÃã']+$/i").WithMessage("Nome aceita apenas de A-Z");
            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Digite a data de nascimento")
                .Must(ValidDate).WithMessage("Data de nascimento tem que ser menor que hoje");
                //.DependentRules(() => { 
                //    RuleFor(x => x.NeedyChild)
                //        .Must(ValidQuestion).WithMessage("Resposta inválida: Você não é criança");
                //});
            RuleFor(x => x.FormOfPayment)
                .NotEmpty().WithMessage("Selecione a forma de pagamento");
            RuleFor(x => x.Seat)
                .NotEmpty().WithMessage("Escolha a poltrona")
                .NotNull().WithMessage("Poltrona inválida");
            RuleFor(x => x.NeedyChild)
                .NotEmpty().WithMessage("Responda a pergunta");
        }

        private static bool ValidDate(DateTime date)
        {
            if(date < DateTime.Now.Date)
            {
                return true;
            }
            return false;
        }

        //private static bool ValidQuestion( resposta)
        //{
        //    int idade = DateTime.Now.Year - date.Year;
        //    bool _resposta = Convert.ToBoolean(resposta);
        //    if(_resposta == true)
        //    {
        //        if(idade >= 2 && idade <=12)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
