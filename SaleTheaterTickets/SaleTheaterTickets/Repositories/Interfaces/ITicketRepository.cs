using SaleTheaterTickets.Models;

namespace SaleTheaterTickets.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        public void Insert(Ticket model);
        public Ticket GetById(int id);
    }
}
