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

            modelBuilder.Entity<Piece>(x =>
            {
                x.HasQueryFilter(piece => EF.Property<bool>(piece, "IsDeleted") == false);
                x.HasKey(p => p.Id);
                x.Property(p => p.Name).HasColumnType("VARCHAR(300)").IsRequired();
            });
            modelBuilder.Entity<Ticket>(x =>
            {
                x.HasKey(p => p.Id);
                x.HasQueryFilter(ticket => EF.Property<bool>(ticket, "IsDeleted") == false);
                x.Property(p => p.Price).HasColumnType("DECIMAL(18,2)").IsRequired();
                x.Property(p => p.QuantityOfSeats).HasColumnType("INT").IsRequired();
                x.Property(p => p.Date).HasColumnType("DATETIME").IsRequired();
                x.Property(p => p.Schedule).HasColumnType("TIME(6)").IsRequired();
                x.HasOne(p => p.Piece).WithMany(p => p.Tickets).HasForeignKey(p => p.PieceId);

            });
            modelBuilder.Entity<GeneratedTicket>(x =>
            {
                x.HasKey(p => p.Id);
                x.Property(p => p.CustomerName).HasColumnType("VARCHAR(400)").IsRequired();
                x.Property(p => p.BirthDate).HasColumnType("DATETIME").IsRequired();
                x.Property(p => p.CreationDate).HasColumnType("DATETIME").IsRequired();
                x.Property(p => p.Description).HasColumnType("LONGTEXT").IsRequired();
                x.Property(p => p.FormOfPayment).HasColumnType("INT").IsRequired();
                x.Property(p => p.NeedyChild).HasColumnType("VARCHAR(10)").IsRequired();
                x.Property(p => p.Seat).HasColumnType("INT").IsRequired();
                x.Property(p => p.Total).HasColumnType("DECIMAL(18,2)").IsRequired();
                x.HasOne(p => p.Ticket).WithMany(p => p.GeneratedTickets).HasForeignKey(p => p.TicketId);
            });
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
