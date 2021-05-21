using SaleTheaterTickets.Models;
using SaleTheaterTickets.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace SaleTheaterTickets.Services
{
    public class GeneratedTicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IGeneratedTicketRepository _generatedTicketRepository;

        public GeneratedTicketService(ITicketRepository ticketRepository, IGeneratedTicketRepository generatedTicketRepository)
        {
            _ticketRepository = ticketRepository;
            _generatedTicketRepository = generatedTicketRepository;
        }

        public int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;

            return age;
        }

        public (decimal, string) CalculateDiscount(int age, decimal priceTicket, string answer)
        {
            decimal discount;
            string description;
            
            if(answer.ToLower() == "false" && (age >= 2 && age <= 12 || age >= 60))
            {
                discount = priceTicket/2;
                description = "Você recebeu desconto de 50% no valor do ingresso!\r\n" +
                    "Regra desconto 50%: Crianças de 2 a 12 anos e idosos a partir de 60 anos.";
                return (discount, description);
            }
            else if(answer.ToLower() == "true")
            {
                discount = priceTicket;
                description = "Você recebeu desconto de 100% no valor do ingresso!\r\n" +
                    "Regra desconto 100%: Crianças da rede pública de ensino.";
                return (discount, description);
            }
            else
            {
                discount = 0;
                description = "Sem desconto";
                return (discount, description);
            }   
        }

        public (GeneratedTicketViewModel, List<int>) GenerateSeats(int ticketId)
        {
            Ticket ticket = _ticketRepository.GetById(ticketId);
            List<int> avaibleSeats = new List<int>();

            for (var count = 1; count <= ticket.QuantityOfSeats; count++)
            {
                GeneratedTicket salesByTicketId = _generatedTicketRepository.FindAllByTicketId(ticket.Id, count);

                if (salesByTicketId == null)
                {
                    avaibleSeats.Add(count);
                }
            }

            GeneratedTicketViewModel generatedTicketViewModel = new GeneratedTicketViewModel();
            generatedTicketViewModel.TicketId = ticketId;

            return (generatedTicketViewModel, avaibleSeats);
        }
    }
}
