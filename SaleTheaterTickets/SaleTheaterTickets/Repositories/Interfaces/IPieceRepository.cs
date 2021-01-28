using SaleTheaterTickets.Models;
using System.Collections.Generic;

namespace SaleTheaterTickets.Repositories.Interfaces
{
    public interface IPieceRepository
    {
        public void Insert(Piece model);
        public Piece GetById(int id);
        public List<Piece> FindAll();
        
    }
}
