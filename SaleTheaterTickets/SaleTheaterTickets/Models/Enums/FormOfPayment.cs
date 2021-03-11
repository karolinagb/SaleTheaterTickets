using System.ComponentModel.DataAnnotations;

namespace SaleTheaterTickets.Models
{
    public enum FormOfPayment : int
    {
        [Display(Name = "Cartão de Débito")]
        DebitCard = 0,
        [Display(Name = "Cartão de Crédito")]
        CreditCard = 1,
        [Display(Name = "Dinheiro")]
        Money = 3
    }
}
