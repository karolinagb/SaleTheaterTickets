using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SaleTheaterTickets.Models
{
    public class TicketViewModel
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Preço")]
        [Range(1, 9999.99, ErrorMessage = "O valor para {0} deve estar entre {1} e {2}.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Quantidade de poltronas")]
        [Range(1, 9999, ErrorMessage = "O valor para {0} deve estar entre {1} e {2}.")]
        public int QuantityOfSeats { get; set; }

        [Required(ErrorMessage = "Digite a Data!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Digite o horário!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        [Display(Name = "Horário")]
        [DataType(DataType.Time)]
        public TimeSpan Schedule { get; set; }

        [Display(Name = "Peça")]
        public int PieceId { get; set; }

        [Display(Name = "Peça")]
        public ICollection<Piece> Pieces { get; set; }

        public ICollection<GeneratedTicket> GeneratedTickets { get; set; }
    }
}
