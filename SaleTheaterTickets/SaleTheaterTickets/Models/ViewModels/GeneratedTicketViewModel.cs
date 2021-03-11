using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaleTheaterTickets.Models
{
    public class GeneratedTicketViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome do cliente")]
        public string CustomerName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        [Display(Name = "Forma de pagamento")]
        public FormOfPayment FormOfPayment { get; set; }

        [Display(Name = "Poltrona")]
        public int Seat { get; set; }

        public int? TicketId { get; set; }

        public Ticket Ticket { get; set; }
    }
}
