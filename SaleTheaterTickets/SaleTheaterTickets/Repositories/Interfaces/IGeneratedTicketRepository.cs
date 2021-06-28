using SaleTheaterTickets.Models;
using System;
using System.Collections.Generic;

namespace SaleTheaterTickets.Repositories.Interfaces
{
    public interface IGeneratedTicketRepository
    {
        public List<GeneratedTicket> FindAll();
        public void Insert(GeneratedTicket model);
        public GeneratedTicket GetById(int id);
        public GeneratedTicket FindAllByTicketId(int ticketId, int seat);
        public List<GeneratedTicket> FindByDateAsync(DateTime minDate, DateTime maxDate);
    }
}
