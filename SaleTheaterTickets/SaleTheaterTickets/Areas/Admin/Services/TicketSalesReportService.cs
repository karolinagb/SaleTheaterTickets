using SaleTheaterTickets.Models;
using SaleTheaterTickets.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace SaleTheaterTickets.Areas.Admin.Services
{
    public class TicketSalesReportService
    {
        private readonly IGeneratedTicketRepository _generatedTicketRepository;

        public TicketSalesReportService(IGeneratedTicketRepository generatedTicketRepository)
        {
            _generatedTicketRepository = generatedTicketRepository;
        }

        public List<GeneratedTicket> FindByDateAsync(DateTime minDate, DateTime maxDate)
        {
            return _generatedTicketRepository.FindByDateAsync(minDate, maxDate);
        }
    }
}
