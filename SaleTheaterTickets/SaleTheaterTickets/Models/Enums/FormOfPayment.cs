using System.ComponentModel.DataAnnotations;

namespace SaleTheaterTickets.Models
{
    public enum FormOfPayment : int
    {
        [Display(Name = "Cartão de Débito")]
        DebitCard = 1,
        [Display(Name = "Cartão de Crédito")]
        CreditCard = 2,
        [Display(Name = "Dinheiro")]
        Money = 3
    }
}
