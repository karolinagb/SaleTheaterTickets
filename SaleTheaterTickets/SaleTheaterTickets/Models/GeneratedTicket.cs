using SaleTheaterTickets.Models;
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
        public string CustomerName { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Total { get; set; }
        public FormOfPayment FormOfPayment { get; set; }
        public int Seat { get; set; }
        public string Description { get; set; }
        public string NeedyChild { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
