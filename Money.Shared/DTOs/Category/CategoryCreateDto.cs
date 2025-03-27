using System.ComponentModel.DataAnnotations;
using Money.Shared.Enums;

namespace Money.Shared.DTOs.Category;

public class CategoryCreateDto
{
    [Required(ErrorMessage = "구분은 필수 항목 입니다")] 
    public MoneyType MoneyType { get; set; }
    
    [Required(ErrorMessage = "카테고리는 필수 항목입니다.")] 
    public string? Name { get; set; }

    [Required(ErrorMessage = "인증 ID는 필수 입니다.")]
    public long? UserId { get; set; } = null;
}