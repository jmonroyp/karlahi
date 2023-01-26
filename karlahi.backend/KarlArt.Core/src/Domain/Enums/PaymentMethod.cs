using System.ComponentModel.DataAnnotations;
namespace KarlArt.Core.Domain.Enums;
public enum PaymentMethod
{
    [Display(Name = "Efectivo")]
    Cash,
    [Display(Name = "Tarjeta de Crédito")]
    CreditCard,
    [Display(Name = "Tarjeta de Débito")]
    DebitCard,
    [Display(Name = "Cheque")]
    Check,
    [Display(Name = "Transferencia")]
    Transfer,
    [Display(Name = "Otro")]
    Other
}