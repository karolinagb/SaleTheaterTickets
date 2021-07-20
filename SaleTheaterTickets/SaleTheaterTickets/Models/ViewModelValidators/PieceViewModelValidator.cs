using FluentValidation;

namespace SaleTheaterTickets.Models.ViewModelValidators
{
    public class PieceViewModelValidator : AbstractValidator<Piece>
    {
        public PieceViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Digite o nome da peça!")
                .MinimumLength(3).WithMessage("O campo deve ter no mínimo 3 letra!");
        }
    }
}
