using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleTheaterTickets.Models.ViewModelValidators
{
    public class PieceViewModelValidator : AbstractValidator<PieceViewModel>
    {
        public PieceViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Digite o nome da peça!")
                .Length(3).WithMessage("O campo deve ter no mínimo 3 letra!");
        }
    }
}
