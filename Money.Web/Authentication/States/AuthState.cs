namespace Money.Web.Authentication.States;

public class AuthState
{
    public long UserId { get; set; } = 0;
    public bool IsAuthenticated => UserId != 0;

    public void SetAuth(long userId)
    {
        UserId = userId;
        NotifyStateChanged();
    }

    public void ClearAuth()
    {
        UserId = 0;
        NotifyStateChanged();
    }

    public event Action? OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();
}