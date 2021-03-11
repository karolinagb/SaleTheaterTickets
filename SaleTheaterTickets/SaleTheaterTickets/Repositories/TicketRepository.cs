using Microsoft.EntityFrameworkCore;
using SaleTheaterTickets.Data;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Repositories.Interfaces;
using System.Collections.Generic;
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
            return _saleTheaterTicketsContext.Tickets.Include(x => x.Piece).FirstOrDefault(x => x.Id == id);
        }

        public List<Ticket> FindAll()
        {
            return _saleTheaterTicketsContext.Tickets.Include(x => x.Piece).ToList();
        }
    }
}
