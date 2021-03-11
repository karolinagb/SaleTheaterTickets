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
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Quantidade de poltronas")]
        public int QuantityOfSeats { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Data")]
        //[DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        [Display(Name = "Horário")]
        [DataType(DataType.Time)]
        public TimeSpan Schedule { get; set; }

        [Display(Name = "Peça")]
        public Piece Piece { get; set; }

        [Display(Name = "Peça")]
        public int PieceId { get; set; }

        public ICollection<Piece> Pieces { get; set; }

        public ICollection<GeneratedTicket> GeneratedTickets { get; set; }

        public ICollection<int> Seats { get; set; }
    }
}
