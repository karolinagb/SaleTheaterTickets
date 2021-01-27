using Microsoft.EntityFrameworkCore;
using SaleTheaterTickets.Models;

namespace SaleTheaterTickets.Data
{
    public class SaleTheaterTicketsContext : DbContext
    {
        public SaleTheaterTicketsContext(DbContextOptions<SaleTheaterTicketsContext> options) : base(options)
        {

        }
        public DbSet<Piece> Pieces { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<GeneratedTicket> GeneratedTickets { get; set; }
    }
}
