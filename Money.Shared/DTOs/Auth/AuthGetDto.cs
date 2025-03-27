using System.ComponentModel.DataAnnotations;

namespace Money.Shared.DTOs.Auth;

public class AuthGetDto
{
    [Required] public string? Email { get; set; }
}