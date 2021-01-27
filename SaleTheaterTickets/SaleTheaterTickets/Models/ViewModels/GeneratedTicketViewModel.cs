using SaleTheaterTickets.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SaleTheaterTickets.Models.ViewModels
{
    public class GeneratedTicketViewModel
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Forma de pagamento")]
        public FormOfPayment FormOfPayment { get; set; }

        [Display(Name = "Poltrona")]
        public int Seat { get; set; }

        public int TicketId { get; set; }

        public Ticket Ticket { get; set; }
    }
}
