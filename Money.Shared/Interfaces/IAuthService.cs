using Money.Shared.DTOs.Auth;

namespace Money.Shared.Interfaces;

/// <summary>
/// 구글 oauth 인증 서비스 
/// </summary>
public interface IAuthService
{
    Task<string?> GetGoogleAuthorizationUrl();

    Task<TokenDetailDto?> GoogleLoginAsync(string code);

    Task<TokenDetailDto?> GetCredentialAsync();
}