using System.ComponentModel.DataAnnotations;

namespace Money.Shared.DTOs.User;

public class UserAddDto
{
    public long? Id { get; set; }
    [Required] public string? UserEmail { get; set; }
}