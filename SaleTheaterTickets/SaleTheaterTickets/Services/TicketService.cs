using SaleTheaterTickets.Models;
using SaleTheaterTickets.Models.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace SaleTheaterTickets.Services
{
    public class TicketService
    {
        private readonly PieceService _pieceService;

        public TicketService(PieceService pieceService)
        {
            _pieceService = pieceService;
        }

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

        public (List<TicketViewModel>, List<string>) ReadCSVData(string filePath)
        {
            //crio um objeto do tipo Piece
            List<TicketViewModel> tickets = new List<TicketViewModel>();

            List<string> logs = new List<string>();

            //Retorna todas as linhas do arquivo em um array
            //de string, onde cada linha será um índice do array
            string[] file = File.ReadAllLines(filePath, Encoding.GetEncoding("ISO-8859-1"));

            //percorro o array e para cada linha
            for (int i = 0; i < file.Length; i++)
            {
                TicketViewModel ticket = new TicketViewModel();

                ticket.Line = i + 1;

                //Uso o método Split e quebro cada linha
                //em um novo array auxiliar, ou seja, cada
                //conteúdo do arquivo txt separado por ',' será
                //um nova linha neste array auxiliar. Assim sei que
                //cada índice representa uma propriedade
                string[] propriedades = file[i].Split(';');

                //Aqui recupero os itens, atribuindo
                //os mesmo as propriedade da classe Piece
                ticket.Price = Convert.ToDecimal(propriedades[0]);
                

                ticket.QuantityOfSeats = Convert.ToInt32(propriedades[1]);
                ticket.Date = Convert.ToDateTime(propriedades[2]);
                ticket.Schedule = TimeSpan.Parse(propriedades[3]);

                var pieceName = propriedades[4];

                ticket.PieceId =  _pieceService.GetByName(pieceName);

                if (ticket.PieceId == 0)
                {
                    logs.Add($"Registro da linha {ticket.Line} - peça {pieceName} não encontrada");
                }


                tickets.Add(ticket);
            }

            return (tickets, logs);
        }
    }
}
