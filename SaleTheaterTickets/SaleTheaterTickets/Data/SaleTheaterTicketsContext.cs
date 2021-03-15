using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SaleTheaterTickets.Models;
using System.Linq;

namespace SaleTheaterTickets.Data
{
    public class SaleTheaterTicketsContext : IdentityDbContext<IdentityUser> //IdentityUser é a classe que gerencia um usuário
    {
        public SaleTheaterTicketsContext(DbContextOptions<SaleTheaterTicketsContext> options) : base(options)
        {

        }

        public DbSet<Piece> Pieces { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<GeneratedTicket> GeneratedTickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Piece>().HasQueryFilter(piece => EF.Property<bool>(piece, "IsDeleted") == false);
            modelBuilder.Entity<Ticket>().HasQueryFilter(ticket => EF.Property<bool>(ticket, "IsDeleted") == false);
        }

        public override int SaveChanges()
        {
            //Soft-Delete
            foreach(var item in ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted && e.Metadata.GetProperties().Any(x => x.Name == "IsDeleted")))
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["IsDeleted"] = true;
            }
            return base.SaveChanges();
        }
    }
}
