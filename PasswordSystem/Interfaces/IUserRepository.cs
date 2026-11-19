namespace PasswordSystem;

public interface IUserRepository
{
    public bool IsEmailRegistered
    (string email);
    public void AddUser
    (string email, string password);
}
