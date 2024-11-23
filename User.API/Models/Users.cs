namespace User.API.Models;

public sealed class Users
{
    private Users(string firstName, string lastName, string email, string password)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    private Users() { }

    public Guid Id { get; }
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string Password { get; private set; } = default!;

    public static Users Create(string firstName, string lastName, string email, string password)
    {
        return new Users(firstName, lastName, email, password);
    }
}
