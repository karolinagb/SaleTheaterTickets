using SaleTheaterTickets.Repositories.Interfaces;

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
    }
}
