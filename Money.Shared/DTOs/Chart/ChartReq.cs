using System.ComponentModel.DataAnnotations;
using Money.Shared.Enums;

namespace Money.Shared.DTOs.Chart;

public class ChartReq
{
    public long? UserId { get; set; } = null;
    
    [Required(ErrorMessage = "date는 필수 입니다.")] 
    public DateTime ChartDate { get; set; } 
    
    public MoneyType MoneyType { get; set; }
}