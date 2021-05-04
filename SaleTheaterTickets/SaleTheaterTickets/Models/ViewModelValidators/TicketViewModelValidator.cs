using AutoMapper;
using FluentValidation;
using SaleTheaterTickets.Repositories.Interfaces;
using System;

namespace SaleTheaterTickets.Models.ViewModelValidators
{
    public class TicketViewModelValidator : AbstractValidator<TicketViewModel>
    {
        //private readonly ITicketRepository _ticketRepository;
        //private readonly IMapper _mapper;

        //public TicketViewModelValidator(ITicketRepository ticketRepository, IMapper mapper)
        //{
        //    _ticketRepository = ticketRepository;
        //    _mapper = mapper;
        //}

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
            //RuleFor(x => x.PieceId)
            //    .Must(BeUniqueByPiece)
            //    .DependentRules(() =>
            //    {
            //        RuleFor(x => x.Date)
            //            .NotEmpty().WithMessage("Digite a Data")
            //            .Must(BeUniqueByDate);
            //    })
            //    .DependentRules(() =>
            //    {
            //        RuleFor(x => x.Schedule)
            //            .NotEmpty().WithMessage("Digite o horário")
            //            .Must(BeUniqueBySchedule);
            //    });

            //RuleFor(ticket => ticket.Id).NotEmpty().Must(BeUnique).WithMessage("Ingresso existente. Verifique data, hora e peça");
        }

        private static bool ValidDate(DateTime date)
        {
            if (date.Date >= DateTime.Now.Date)
            {
                return true;
            }

            return false;
        }

        //private bool BeUnique(int id)
        //{
        //    var model = _ticketRepository.GetById(id);
        //    if (_ticketRepository.BeUnique(model) > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //private bool BeUniqueByPiece(int pieceId)
        //{
        //    var count = _ticketRepository.BeUniqueByPiece(pieceId);
        //    if (count > 0)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        //private bool BeUniqueByDate(DateTime date)
        //{
        //    var count = _ticketRepository.BeUniqueByDate(date.Date);
        //    if (count > 0)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        //private bool BeUniqueBySchedule(TimeSpan schedule)
        //{
        //    var count = _ticketRepository.BeUniqueBySchedule(schedule);
        //    if (count > 0)
        //    {
        //        return true;
        //    }

        //    return false;
        //}
    }
}
