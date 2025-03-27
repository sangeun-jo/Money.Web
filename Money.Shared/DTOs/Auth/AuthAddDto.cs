using System.ComponentModel.DataAnnotations;

namespace Money.Shared.DTOs.Auth;

public class AuthAddDto
{
    [Required] public string? MemberName { get; set; }
    [Required] public string? Email { get; set; }
}