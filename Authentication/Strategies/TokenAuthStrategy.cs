using System.Net.Http.Headers;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Money.Shared.DTOs.Auth;
using Money.Web.Authentication.Services;

namespace Money.Web.Authentication.Strategies;

public interface IAuthStrategy 
{
    Task ApplyAuthenticationAsync(HttpRequestMessage request);
}

public class TokenAuthStrategy : IAuthStrategy
{
    private readonly ILocalStorageService _localStorage;
    private readonly NavigationManager _navigationManager;
    private readonly HttpClient _httpClient;
    private readonly SemaphoreSlim _semaphore = new(1, 1);
    private readonly JsonSerializerOptions _options = new() { PropertyNameCaseInsensitive = true };

    public TokenAuthStrategy(
        ILocalStorageService localStorage,
        NavigationManager navigationManager,
        HttpClient httpClient)
    {
        _localStorage = localStorage;
        _navigationManager = navigationManager;
        _httpClient = httpClient;
    }

    public async Task ApplyAuthenticationAsync(HttpRequestMessage request)
    {
        var accessToken = await TryRefreshTokenAsync();
        
        if (string.IsNullOrWhiteSpace(accessToken) || accessToken.Equals("null"))
        {
            _navigationManager.NavigateTo("/login");
        }
        else
        {
            request.Headers.Authorization = 
                new AuthenticationHeaderValue("Bearer", accessToken);
        }
    }

    private async Task<string?> GetNewTokenAsync(string accessToken, string refreshToken)
    {
        // 토큰 갱신 요청을 위한 임시 HttpClient 사용 
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/auth/refresh?refreshToken={refreshToken}");
        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
        
        var responseMessage = await _httpClient.SendAsync(requestMessage);
        var tokenResponseString = await responseMessage.Content.ReadAsStringAsync();
        var tokenResponse = JsonSerializer.Deserialize<TokenDetailDto>(tokenResponseString, _options);

        if (!responseMessage.IsSuccessStatusCode)
        {
            _navigationManager.NavigateTo("/logout", true);
            return null;
        }

        await _localStorage.SetItemAsStringAsync("a", tokenResponse?.AccessToken!);
        await _localStorage.SetItemAsStringAsync("r", tokenResponse?.RefreshToken!);

        return tokenResponse?.AccessToken;
    }

    private async Task<string?> TryRefreshTokenAsync()
    {
        await _semaphore.WaitAsync();

        try
        {
            var accessToken = await _localStorage.GetItemAsStringAsync("a");

            var claims = JwtParser.ParseClaimsFromJwt(accessToken);
            var exp = claims?.FirstOrDefault(x => x.Type.Equals("exp"))?.Value;
            
            if (string.IsNullOrEmpty(exp))
            {
                return accessToken;
            }
            
            var expTime = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(exp));
            var timeUtc = DateTime.UtcNow;
            var diff = expTime - timeUtc;

            if (diff.TotalMinutes <= 2) // 만료 2분전
            {
                var refreshToken = await _localStorage.GetItemAsStringAsync("r");
                var newAccessToken = await GetNewTokenAsync(accessToken, refreshToken);
                return newAccessToken;
            }

            return accessToken;
        }
        catch
        {
            _navigationManager.NavigateTo("/login");
        }
        finally
        {
            _semaphore.Release();
        }
        
        return null;
    }
}

public class NoAuthStrategy : IAuthStrategy
{
    public Task ApplyAuthenticationAsync(HttpRequestMessage request)
    {
        // 인증 없음 
        return Task.CompletedTask;
    }
}