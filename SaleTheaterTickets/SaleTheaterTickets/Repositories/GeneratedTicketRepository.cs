﻿using Microsoft.EntityFrameworkCore;
using SaleTheaterTickets.Data;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SaleTheaterTickets.Repositories
{
    public class GeneratedTicketRepository : IGeneratedTicketRepository
    {
        private readonly SaleTheaterTicketsContext _saleTheaterTicketsContext;

        public GeneratedTicketRepository(SaleTheaterTicketsContext saleTheaterTicketsContext)
        {
            _saleTheaterTicketsContext = saleTheaterTicketsContext;
        }

        public List<GeneratedTicket> FindAll()
        {
            return _saleTheaterTicketsContext.GeneratedTickets.ToList();
        }

        public GeneratedTicket FindAllByTicketId(int ticketId, int seat)
        {
            return _saleTheaterTicketsContext.GeneratedTickets.Where(x => x.TicketId == ticketId).Where(x => x.Seat == seat).FirstOrDefault();
        }

        public GeneratedTicket GetById(int id)
        {
            return _saleTheaterTicketsContext.GeneratedTickets.Include(x => x.Ticket).FirstOrDefault(x => x.Id == id);
        }

        public void Insert(GeneratedTicket model)
        {
            _saleTheaterTicketsContext.GeneratedTickets.Add(model);
            _saleTheaterTicketsContext.SaveChanges();
        }
    }
}
