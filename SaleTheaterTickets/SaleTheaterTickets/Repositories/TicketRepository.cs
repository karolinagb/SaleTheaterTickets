using SaleTheaterTickets.Data;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Repositories.Interfaces;
using System.Linq;

namespace SaleTheaterTickets.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly SaleTheaterTicketsContext _saleTheaterTicketsContext;

        public TicketRepository(SaleTheaterTicketsContext saleTheaterTicketsContext)
        {
            _saleTheaterTicketsContext = saleTheaterTicketsContext;
        }

        public void Insert(Ticket model)
        {
            _saleTheaterTicketsContext.Tickets.Add(model);
            _saleTheaterTicketsContext.SaveChanges();
        }

        public Ticket GetById(int id)
        {
            return _saleTheaterTicketsContext.Tickets.FirstOrDefault(x => x.Id == id);
        }
    }
}
