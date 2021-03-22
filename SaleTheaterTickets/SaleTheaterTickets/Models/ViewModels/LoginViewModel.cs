using System.ComponentModel.DataAnnotations;

namespace SaleTheaterTickets.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Display(Name = "Senha")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
