using SaleTheaterTickets.Models;
using System.Collections.Generic;

namespace SaleTheaterTickets.Repositories.Interfaces
{
    public interface IGeneratedTicketRepository
    {
        public List<GeneratedTicket> FindAll();
        public void Insert(GeneratedTicket model);
        public GeneratedTicket GetById(int id);
    }
}
