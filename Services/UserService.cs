using Minis.Shared.Dtos.Member;
using Money.Shared.DTOs.Auth;
using Money.Shared.Interfaces;

namespace Money.Web.Services;

public class UserService : IUserService
{
    private readonly IHttpService _httpService;

    public UserService(IHttpService httpService)
    {
        _httpService = httpService;
    }


    public async Task<UserDetailDto?> GetUserAsync()
    {
        return await _httpService.GetAsync<UserDetailDto>("/api/user");
    }

    public Task<UserDetailDto?> GetUserByEmailAsync(string? email)
    {
        throw new NotImplementedException();
    }

    public Task<long?> CreateUserAsync(string? email)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUserAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(long id)
    {
        throw new NotImplementedException();
    }
}