using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleTheaterTickets.Models
{
    public class Piece
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
