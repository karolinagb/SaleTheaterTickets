using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaleTheaterTickets.Models.ViewModels
{
    public class PieceViewModel
    {
        [Display(Name = "Código da peça")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Digite o nome da peça!")]
        public string Name { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
