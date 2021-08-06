using FluentValidation;
using SaleTheaterTickets.Models.Services;

namespace SaleTheaterTickets.Models.ViewModelValidators
{
    public class PieceViewModelValidator : AbstractValidator<Piece>
    {
        private readonly PieceService _pieceService;

        public PieceViewModelValidator(PieceService pieceService)
        {
            _pieceService = pieceService;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Digite o nome da peça!")
                .MinimumLength(3).WithMessage("O campo deve ter no mínimo 3 letra!")
                .Must(BeUnique).WithMessage(x => $"Já existe uma peça com o nome {x.Name}");
        }

        public bool BeUnique(string name)
        {
            if (_pieceService.BeUnique(name) == 0)
            {
                return true;
            }
            return false;
        }
    }
}
