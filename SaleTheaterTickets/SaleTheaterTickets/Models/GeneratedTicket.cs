using System;
using System.ComponentModel.DataAnnotations;

namespace SaleTheaterTickets.Models
{
    public class GeneratedTicket
    {
        public int Id { get; set; }

        [Display(Name = "Nome do cliente")]
        public string CustomerName { get; set; }

        [Display(Name = "Data de nascimento")]
        public DateTime BirthDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        [Display(Name = "Forma de pagamento")]
        public FormOfPayment FormOfPayment { get; set; }

        [Display(Name = "Poltrona")]
        public int Seat { get; set; }

        [Display(Name = "Criança carente da rede pública de ensino?")]
        public string NeedyChild { get; set; }

        public int? TicketId { get; set; }

        public Ticket Ticket { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }
    }
}
