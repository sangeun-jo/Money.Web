using System.ComponentModel.DataAnnotations;

namespace Money.Shared.Enums;

public enum MoneyType
{
    [Display(Name="지출")]
    Expense,
    
    [Display(Name = "수입")]
    Income,
    
    // [Display(Name = "이체")]
    // Transfer
}