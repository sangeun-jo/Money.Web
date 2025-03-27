using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Money.Web.Authentication.Services;

namespace Money.Web.Authentication.States;


public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly AuthState _authState;
    private readonly ILocalStorageService _localStorage;

    public CustomAuthStateProvider(
        AuthState authState, ILocalStorageService localStorage)
    {
        _authState = authState;
        _localStorage = localStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var accessToken = await _localStorage.GetItemAsStringAsync("a");
        
        if (string.IsNullOrWhiteSpace(accessToken) || accessToken.Equals("null"))
        {
            _authState.ClearAuth();
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        var claims = JwtParser.ParseClaimsFromJwt(accessToken);
        var userIdString = claims.FirstOrDefault(x => x.Type.Equals("userId"))?.Value;
        var userId = Convert.ToInt64(userIdString);
        
        _authState.SetAuth(userId);
        
        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "userId")));
    }

    public void NotifyAuthenticationChanged()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}