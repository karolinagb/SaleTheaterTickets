using SaleTheaterTickets.Data;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleTheaterTickets.Repositories
{
    public class PieceRepository : IPieceRepository
    {
        private readonly SaleTheaterTicketsContext _saleTheaterTicketsContext;

        public PieceRepository(SaleTheaterTicketsContext saleTheaterTicketsContext)
        {
            _saleTheaterTicketsContext = saleTheaterTicketsContext;
        }

        public void Insert(Piece model)
        {
            _saleTheaterTicketsContext.Pieces.Add(model);
            _saleTheaterTicketsContext.SaveChanges();
        }
    }
}
