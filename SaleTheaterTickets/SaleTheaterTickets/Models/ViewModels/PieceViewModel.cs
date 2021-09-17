using System.Collections.Generic;

namespace SaleTheaterTickets.Models.ViewModels
{
    public class PieceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public bool IsDeleted { get; set; }
        public int Line { get; set; }
    }
}
