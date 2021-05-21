using System;

namespace SaleTheaterTickets.Services
{
    public class GeneratedTicketService
    {
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
    }
}
