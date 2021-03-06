﻿using SaleTheaterTickets.Models;
using System.Collections.Generic;

namespace SaleTheaterTickets.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        public void Insert(Ticket model);
        public Ticket GetById(int id);
        public List<Ticket> FindAll();
        public void Update(Ticket model);
        public void Remove(int id);
        public int BeUnique(Ticket model);

        //public int BeUniqueByPiece(int pieceId);
        //public int BeUniqueByDate(DateTime date);
        //public int BeUniqueBySchedule(TimeSpan schedule);
    }
}
