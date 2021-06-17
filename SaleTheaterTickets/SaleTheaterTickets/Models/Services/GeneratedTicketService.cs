using SaleTheaterTickets.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaleTheaterTickets.Models.Services
{
    public class GeneratedTicketService
    {
        private readonly IGeneratedTicketRepository _generatedTicketRepository;

        public GeneratedTicketService(IGeneratedTicketRepository generatedTicketRepository)
        {
            _generatedTicketRepository = generatedTicketRepository;
        }

        //public async Task<List<GeneratedTicket>> FindByDateAsync(DateTime? minDate, DateTime: maxDate)
        //{
        //    var result = _generatedTicketRepository.FindAll();

        //    if (minDate.HasValue)
        //    {

        //    }
        //}
    }
}
