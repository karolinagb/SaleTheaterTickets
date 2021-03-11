using System.Collections.Generic;

namespace SaleTheaterTickets.Models
{
    public class Piece
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public bool IsDeleted { get; set; }
    }
}
