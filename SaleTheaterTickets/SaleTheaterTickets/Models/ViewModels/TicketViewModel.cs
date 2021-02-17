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

        [Required(ErrorMessage = "Digite o preço do Ingresso!")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Digite a quantidade de poltronas!")]
        [Display(Name = "Quantidade de poltronas")]
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

        [Required(ErrorMessage = "Escolha a peça!")]
        [Display(Name = "Peça")]
        public int PieceId { get; set; }

        [Display(Name = "Peça")]
        public ICollection<Piece> Pieces { get; set; }

        public ICollection<GeneratedTicket> GeneratedTickets { get; set; }
    }
}
