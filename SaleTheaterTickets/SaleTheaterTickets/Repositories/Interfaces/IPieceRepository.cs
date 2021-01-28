﻿using SaleTheaterTickets.Models;

namespace SaleTheaterTickets.Repositories.Interfaces
{
    public interface IPieceRepository
    {
        public void Insert(Piece model);
        public Piece GetById(int id);
        
    }
}