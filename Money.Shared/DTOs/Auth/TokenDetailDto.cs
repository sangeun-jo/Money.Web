namespace Money.Shared.DTOs.Auth;

public class TokenDetailDto
{
    public string? AccessToken { get; set; }
    
    public string? RefreshToken { get; set; }
    
}