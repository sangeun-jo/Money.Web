using System.ComponentModel.DataAnnotations;

namespace Money.Shared.DTOs.Auth;

public class TokenSaveDto
{
    
    [Required(ErrorMessage = "사용자 ID는 필수 입니다.")]
    public long UserId { get; set; }
    
    [Required(ErrorMessage = "엑세스 토큰은 필수 입니다.")]
    public string? AccessToken { get; set; }
    
    [Required(ErrorMessage = "리프레시 토큰은 필수 입니다.")]
    public string? RefreshToken { get; set; }
    
}