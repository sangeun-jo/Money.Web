using System.ComponentModel.DataAnnotations;

namespace Minis.Shared.Dtos.Member;

public class UserDetailDto
{
    public long Id { get; set; }
    public string? UserEmail { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? LastLoginDate { get; set; }
}