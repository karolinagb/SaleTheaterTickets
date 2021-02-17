﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaleTheaterTickets.Data;

namespace SaleTheaterTickets.Migrations
{
    [DbContext(typeof(SaleTheaterTicketsContext))]
    partial class SaleTheaterTicketsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SaleTheaterTickets.Models.GeneratedTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FormOfPayment")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Seat")
                        .HasColumnType("int");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("GeneratedTickets");
                });

            modelBuilder.Entity("SaleTheaterTickets.Models.Piece", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Pieces");
                });

            modelBuilder.Entity("SaleTheaterTickets.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PieceId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("QuantityOfSeats")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Schedule")
                        .HasColumnType("time(6)");

                    b.HasKey("Id");

                    b.HasIndex("PieceId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("SaleTheaterTickets.Models.GeneratedTicket", b =>
                {
                    b.HasOne("SaleTheaterTickets.Models.Ticket", "Ticket")
                        .WithMany("GeneratedTickets")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SaleTheaterTickets.Models.Ticket", b =>
                {
                    b.HasOne("SaleTheaterTickets.Models.Piece", "Piece")
                        .WithMany("Tickets")
                        .HasForeignKey("PieceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
