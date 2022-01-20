using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SaleTheaterTickets.Models
{
    public class TicketViewModel
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Preço")]
        public decimal Price { get; set; }

        [Display(Name = "Quantidade de poltronas")]
        public int QuantityOfSeats { get; set; }

        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        [Display(Name = "Horário")]
        public TimeSpan Schedule { get; set; }

        [Display(Name = "Peça")]
        public Piece Piece { get; set; }

        [Display(Name = "Peça")]
        public int PieceId { get; set; }

        public ICollection<Piece> Pieces { get; set; }

        public ICollection<GeneratedTicket> GeneratedTickets { get; set; }

        public ICollection<int> Seats { get; set; }

        public int QuantityAvaibleSeats { get; set; }

        public int Line { get; set; }
    }
}
