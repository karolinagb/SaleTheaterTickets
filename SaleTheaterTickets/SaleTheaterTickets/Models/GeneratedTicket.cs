using SaleTheaterTickets.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SaleTheaterTickets.Models
{
    public class GeneratedTicket
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public FormOfPayment FormOfPayment { get; set; }
        public int Seat { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
