using System.ComponentModel.DataAnnotations;

namespace SaleTheaterTickets.Models
{
    public class RegisterViewModel
    {
        [Display(Name= "Email")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Confirme a senha")]
        public string ConfirmPassword { get; set; }
    }
}
