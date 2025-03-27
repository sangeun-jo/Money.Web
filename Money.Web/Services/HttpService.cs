using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Money.Web.Authentication.Strategies;

public interface IHttpService 
{
    Task<T?> GetAsync<T>(string uri);
    Task PostAsync(string uri, object obj);
    Task<T?> PostReturnAsync<T>(string uri, object obj);
    Task PutAsync(string uri, object obj);
    Task<T?> PutReturnAsync<T>(string uri, object obj);
    Task DeleteAsync(string uri);
    Task<string?> GetStringAsync(string uri);
    IHttpService WithStrategy(IAuthStrategy strategy);
}


public class HttpService : IHttpService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;
  
    private readonly IAuthStrategy _defaultStrategy;
    private IAuthStrategy _currentStrategy; 

    public HttpService(HttpClient client, IAuthStrategy defaultStrategy) 
    {
        _client = client;
        _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) 
            }
        };
        _defaultStrategy = defaultStrategy;
        _currentStrategy = defaultStrategy;
    }

    public IHttpService WithStrategy(IAuthStrategy strategy)
    {
        _currentStrategy = strategy;
        return this;
    }
    
    public async Task<T?> GetAsync<T>(string uri)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        await _currentStrategy.ApplyAuthenticationAsync(request);
        
        var responseMessage = await _client.SendAsync(request);
        var result = await GetResponseAsync<T>(responseMessage);
        
        _currentStrategy = _defaultStrategy;

        return result;
    }
    

    public async Task<string?> GetStringAsync(string uri)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        await _currentStrategy.ApplyAuthenticationAsync(request);
        
        var responseMessage = await _client.SendAsync(request);
        var result = await responseMessage.Content.ReadAsStringAsync();

        _currentStrategy = _defaultStrategy;

        return result;
    }
    public async Task PostAsync(string uri, object obj)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.Content = JsonContent.Create(obj);
        
        await _currentStrategy.ApplyAuthenticationAsync(request);
        
        var responseMessage = await _client.SendAsync(request);
        await GetResponseAsync(responseMessage);
        
        _currentStrategy = _defaultStrategy;
    }

    public async Task<T?> PostReturnAsync<T>(string uri, object obj)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.Content = JsonContent.Create(obj);
        
        await _currentStrategy.ApplyAuthenticationAsync(request);
        
        var responseMessage = await _client.SendAsync(request);
        var result = await GetResponseAsync<T>(responseMessage);

        _currentStrategy = _defaultStrategy;
        
        return result;
    }

    public async Task PutAsync(string uri, object obj)
    {
        using var request = new HttpRequestMessage(HttpMethod.Put, uri);
        request.Content = JsonContent.Create(obj);
        
        await _currentStrategy.ApplyAuthenticationAsync(request);
        
        var responseMessage = await _client.SendAsync(request);
        await GetResponseAsync(responseMessage);

        _currentStrategy = _defaultStrategy;
    }

    public async Task<T?> PutReturnAsync<T>(string uri, object obj)
    {
        using var request = new HttpRequestMessage(HttpMethod.Put, uri);
        request.Content = JsonContent.Create(obj);
        
        await _currentStrategy.ApplyAuthenticationAsync(request);
        
        var responseMessage = await _client.SendAsync(request);
        var result = await GetResponseAsync<T>(responseMessage);
        
        _currentStrategy = _defaultStrategy;

        return result;

    }

    public async Task DeleteAsync(string uri)
    {
        using var request = new HttpRequestMessage(HttpMethod.Delete, uri);
        await _currentStrategy.ApplyAuthenticationAsync(request);
        
        var responseMessage = await _client.SendAsync(request);
        await GetResponseAsync(responseMessage);
        
        _currentStrategy = _defaultStrategy;
    }


    private async Task GetResponseAsync(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            throw new Exception(errorMessage);
        }
    }

    private async Task<T?> GetResponseAsync<T>(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode){
            var errorMessage = await response.Content.ReadAsStringAsync();
            throw new Exception(errorMessage);
        }

        var json = await response.Content.ReadAsStringAsync();
        return string.IsNullOrWhiteSpace(json) ? default : JsonSerializer.Deserialize<T>(json, _options);
    }
}
