using System.ComponentModel.DataAnnotations;

namespace Money.Shared.Enums;

public enum AssetType
{
    // 현금
    [Display(Name = "현금")] 
    Cash,
    // 은행
    [Display(Name = "은행")] 
    Bank,
    // 신용카드
    [Display(Name = "신용카드")] 
    CreditCard,
    // 체크카드
    [Display(Name = "체크카드")] 
    CheckCard,
    // 투자
    [Display(Name = "투자")] 
    Invest,
    // 보증금
    [Display(Name = "보증금")] 
    Deposit,
    // 저축
    [Display(Name = "저축")] 
    Savings
}