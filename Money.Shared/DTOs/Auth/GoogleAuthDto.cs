namespace Money.Shared.DTOs.Auth;

public class GoogleAuthDto
{
    public string? Email { get; set; }
    public string? MemberName { get; set; }

    public GoogleAuthDto(string? email, string memberName)
    {
        Email = email;
        MemberName = memberName;
    }
}