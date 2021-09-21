using FluentValidation.Results;
using SaleTheaterTickets.Models.ViewModels;
using SaleTheaterTickets.Models.ViewModelValidators;
using SaleTheaterTickets.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SaleTheaterTickets.Models.Services
{
    public class PieceService
    {
        private readonly IPieceRepository _pieceRepository;

        public PieceService(IPieceRepository pieceRepository)
        {
            _pieceRepository = pieceRepository;
        }

        public int BeUnique(string name)
        {
            return _pieceRepository.BeUnique(name);
        }

        public List<PieceViewModel> ReadCSVData(string filePath)
        {
            //crio um objeto do tipo Piece
            List<PieceViewModel> pieces = new List<PieceViewModel>();

            //Retorna todas as linhas do arquivo em um array
            //de string, onde cada linha será um índice do array
            string[] file = File.ReadAllLines(filePath, Encoding.GetEncoding("ISO-8859-1"));

            //percorro o array e para cada linha
            for (int i = 0; i < file.Length; i++)
            {
                PieceViewModel piece = new PieceViewModel();

                //Uso o método Split e quebro cada linha
                //em um novo array auxiliar, ou seja, cada
                //conteúdo do arquivo txt separado por ',' será
                //um nova linha neste array auxiliar. Assim sei que
                //cada índice representa uma propriedade
                string[] propriedades = file[i].Split(',');

                //Aqui recupero os itens, atribuindo
                //os mesmo as propriedade da classe Piece
                piece.Name = propriedades[0];
                piece.Line = i + 1;
                pieces.Add(piece);
            }

            return pieces;
        }
    }
}
