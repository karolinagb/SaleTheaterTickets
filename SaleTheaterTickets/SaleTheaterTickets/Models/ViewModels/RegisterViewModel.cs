using System.ComponentModel.DataAnnotations;

namespace SaleTheaterTickets.Models
{
    public class RegisterViewModel
    {
        [Display(Name= "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Confirmação de senha")]
        public string ConfirmPassword { get; set; }
    }
}
