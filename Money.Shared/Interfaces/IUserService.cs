using Minis.Shared.Dtos.Member;
using Money.Shared.DTOs.Auth;

namespace Money.Shared.Interfaces;

/// <summary>
/// 사용자 
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Id로 인증 정보 조회(id는 jwt에서 파싱)
    /// </summary>
    Task<UserDetailDto?> GetUserAsync();
    
    /// <summary>
    /// 이메일로 조회
    /// </summary>
    Task<UserDetailDto?> GetUserByEmailAsync(string? email);
    
    /// <summary>
    /// 사용자 추가
    /// </summary>
    Task<long?> CreateUserAsync(string? email);
    
    /// <summary>
    /// 사용자 수정
    /// </summary>
    Task UpdateUserAsync(string email);

    /// <summary>
    /// 사용자 삭제
    /// </summary>
    Task DeleteUserAsync(long id);
}