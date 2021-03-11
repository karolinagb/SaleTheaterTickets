﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SaleTheaterTickets.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int QuantityOfSeats { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Schedule { get; set; }
        public int PieceId { get; set; }
        public Piece Piece { get; set; }
        public ICollection<GeneratedTicket> GeneratedTickets { get; set; }
        public bool IsDeleted { get; set; }
    }
}
