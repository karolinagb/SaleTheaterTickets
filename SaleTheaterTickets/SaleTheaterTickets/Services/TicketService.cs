using System.Collections.Generic;

namespace SaleTheaterTickets.Services
{
    public class TicketService
    {
        public List<int> RegistrationSeats(int quantityOfSeats)
        {
            List<int> Seats = new List<int>();
            var contador = 1;
            while (contador <= quantityOfSeats)
            {
                Seats.Add(contador);
                contador++;
            }

            return Seats;
        }
    }
}
