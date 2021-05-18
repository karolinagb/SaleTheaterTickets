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

        public decimal CalculateDiscount(int age, decimal priceTicket, string answer)
        {
            decimal discount;
            
            if(answer.ToLower() == "false" && (age >= 2 && age <= 12 || age >= 60))
            {
                discount = priceTicket/2;
                return discount;
            }
            else if(answer.ToLower() == "true")
            {
                discount = priceTicket;
                return discount;
            }
            else
            {
                discount = 0;
                return discount;
            }   
        }
    }
}
