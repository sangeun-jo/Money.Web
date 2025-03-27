using Money.Shared.DTOs.Auth;
using Money.Shared.Interfaces;
using Money.Web.Authentication.Strategies;

namespace Money.Web.Authentication.Services;

internal class AuthService : IAuthService
{
    private readonly IHttpService _httpService;
    private readonly NoAuthStrategy _noAuthStrategy;
    
    public AuthService(IHttpService httpService, NoAuthStrategy noAuthStrategy)
    {
        _httpService = httpService;
        _noAuthStrategy = noAuthStrategy;
    }
    
    public async Task<string?> GetGoogleAuthorizationUrl()
    {
        return await _httpService.WithStrategy(_noAuthStrategy).GetStringAsync("/auth");
    }

    public async Task<TokenDetailDto?> GoogleLoginAsync(string code)
    {
        throw new NotImplementedException();
    }
    
    public async Task<TokenDetailDto?> GetCredentialAsync()
    {
        return await _httpService.GetAsync<TokenDetailDto>("/auth/token");
    }
}