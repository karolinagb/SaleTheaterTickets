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

        public void Update(Ticket model)
        {
            _saleTheaterTicketsContext.Tickets.Update(model);
            _saleTheaterTicketsContext.SaveChanges();
        }

        public void Remove(int id)
        {
            var model = _saleTheaterTicketsContext.Tickets.Find(id);
            _saleTheaterTicketsContext.Tickets.Remove(model);
            _saleTheaterTicketsContext.SaveChanges();
        }

        public int BeUnique(Ticket model)
        {
            return _saleTheaterTicketsContext.Tickets.Include(x => x.Piece).Where( x => x.Id != model.Id && x.PieceId == model.PieceId
            && x.Date == model.Date && x.Schedule == model.Schedule).Count();
        }

        //public int BeUniqueByPiece(int pieceId)
        //{
        //    return _saleTheaterTicketsContext.Tickets.Include(x => x.Piece).Where(x => x.PieceId == pieceId).Count();
        //}

        //public int BeUniqueByDate(DateTime date)
        //{
        //    return _saleTheaterTicketsContext.Tickets.Include(x => x.Piece).Where(x => x.Date == date).Count();
        //}

        //public int BeUniqueBySchedule(TimeSpan schedule)
        //{
        //    return _saleTheaterTicketsContext.Tickets.Include(x => x.Piece).Where(x => x.Schedule == schedule).Count();
        //}
    }
}
