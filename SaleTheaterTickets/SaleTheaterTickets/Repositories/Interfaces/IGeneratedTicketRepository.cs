using SaleTheaterTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaleTheaterTickets.Repositories.Interfaces
{
    public interface IGeneratedTicketRepository
    {
        public List<GeneratedTicket> FindAll();
        public void Insert(GeneratedTicket model);
        public GeneratedTicket GetById(int id);
        public GeneratedTicket GetByTicketId(int ticketId, int seat);
        public List<GeneratedTicket> FindByDateAsync(DateTime minDate, DateTime maxDate);
        public IQueryable<GeneratedTicket> FindAllToPagination();
    }
}
