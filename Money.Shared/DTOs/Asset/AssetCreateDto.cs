using System.ComponentModel.DataAnnotations;
using Money.Shared.Enums;

namespace Money.Shared.DTOs.Asset;

public class AssetCreateDto
{
    [Required(ErrorMessage = "자산 종류는 필수 항목 입니다.")] 
    public AssetType AssetType { get; set; }
    
    [Required(ErrorMessage = "자산 이름은 필수 항목 입니다.")] 
    public string? Name { get; set; }
    
        
    [Required(ErrorMessage = "자산 금액은 필수 항목 입니다.")] 
    public int? Amount { get; set; }

    public long? UserId { get; set; } = null;
}