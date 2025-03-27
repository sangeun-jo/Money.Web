using System.ComponentModel.DataAnnotations;
using Money.Shared.Enums;

namespace Money.Shared.DTOs.History;

public class HistoryUpdateDto
{
    [Required(ErrorMessage = "Id는 필수 항목입니다.")] 
    public long Id { get; set; }
    [Required(ErrorMessage = "구분은 필수 항목입니다.")] 
    public MoneyType MoneyType { get; set; }
    
    [Required(ErrorMessage = "카테고리는 필수 항목입니다.")] 
    public int? CategoryId { get; set; }
    
    [Required(ErrorMessage = "금액은 필수 항목입니다.")] 
    public int? Amount { get; set; }
    [MaxLength(20, ErrorMessage = "20자 이하로 입력해주세요.")] 
    public string? Place { get; set; }
    
    [MaxLength(200, ErrorMessage = "200자 이하로 입력해주세요.")] 
    public string? Note { get; set; }
    
    [Required(ErrorMessage = "날짜는 필수 항목입니다.")] 
    public DateTime? CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    
}