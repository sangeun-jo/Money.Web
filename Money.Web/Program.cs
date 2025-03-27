using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Money.Shared.Interfaces;
using Money.Web;
using Money.Web.Authentication.Services;
using Money.Web.Services;
using Money.Web.Authentication.States;
using Money.Web.Authentication.Strategies;
using MudBlazor.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var configuration = builder.Configuration;


// api 주소 확인
var baseUrl = configuration["BaseUrl"];
if(string.IsNullOrWhiteSpace(baseUrl)){
    throw new Exception("BaseUrl 확인해주세요.");
}

var services = builder.Services;


// 기본 서비스 등록
services.AddBlazoredLocalStorageAsSingleton();

// 인증 관련

services.AddCascadingAuthenticationState();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthState>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

//  HTTP 관련
services.AddScoped(sp => 
    new HttpClient { BaseAddress = new Uri(baseUrl) });

// 인증 전략 등록
services.AddScoped<NoAuthStrategy>();
services.AddScoped<TokenAuthStrategy>();
services.AddScoped<IAuthStrategy, TokenAuthStrategy>(); // 기본값

// 서비스 등록
services.AddScoped<IAuthService, AuthService>();
services.AddScoped<IHttpService, HttpService>();
services.AddScoped<IHistoryService, HistoryService>();
services.AddScoped<ICategoryService, CategoryService>();
services.AddScoped<IAssetService, AssetService>();
services.AddScoped<IChartService, ChartService>();
services.AddScoped<IUserService, UserService>();

services.AddMudServices();

var app = builder.Build();
await app.RunAsync();