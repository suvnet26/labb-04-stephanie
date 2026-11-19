namespace PasswordSystem.Tests;

public class FakeUserRepository : IUserRepository
{
private readonly List<string> _registeredEmails = new();

    public bool IsEmailRegistered(string email)
    {
        return _registeredEmails.Contains(email.ToLowerInvariant());
    }

    public void AddUser(string email, string password)
    {
        if (!IsEmailRegistered(email))
        {
            _registeredEmails.Add(email.ToLowerInvariant());
        }
    }
}
