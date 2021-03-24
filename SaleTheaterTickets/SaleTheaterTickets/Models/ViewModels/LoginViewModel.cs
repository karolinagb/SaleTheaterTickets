using System.ComponentModel.DataAnnotations;

namespace SaleTheaterTickets.Models
{
    public class LoginViewModel
    {
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
