﻿using SaleTheaterTickets.Data;
using SaleTheaterTickets.Models;
using SaleTheaterTickets.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Piece GetById(int id)
        {
            return _saleTheaterTicketsContext.Pieces.FirstOrDefault(x => x.Id == id);
        }

        public List<Piece> FindAll()
        {
            return _saleTheaterTicketsContext.Pieces.ToList();
        }

        public void Update(Piece model)
        {
            _saleTheaterTicketsContext.Pieces.Update(model);
            _saleTheaterTicketsContext.SaveChanges();
        }

        public void Remove(int id)
        {
            var model = _saleTheaterTicketsContext.Pieces.Find(id);
            _saleTheaterTicketsContext.Pieces.Remove(model);
            _saleTheaterTicketsContext.SaveChanges();
        }

        public int BeUnique(string name)
        {
            return _saleTheaterTicketsContext.Pieces.Where(x => x.Name.ToLower().Replace(" ", String.Empty) == name.ToLower().Replace(" ", String.Empty)).Count();
        }

        public int GetByName(string name)
        {
            return _saleTheaterTicketsContext.Pieces.Where(x => x.Name.ToLower().Replace(" ", String.Empty) == name.ToLower().Replace(" ", String.Empty)).Select(x => x.Id).FirstOrDefault();
        }
    }
}
