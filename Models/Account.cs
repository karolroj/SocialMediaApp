namespace SocialMediaApp.Models;

public class Account
{
    public Account(string name, string surname, string email, string password)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException($"'{nameof(name)}' cannot be empty.");
        }

        if (string.IsNullOrEmpty(surname))
        {
            throw new ArgumentException($"'{nameof(surname)}' cannot be empty.");
        }

        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException($"'{nameof(email)}' cannot be empty.");
        }

        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException($"'{nameof(password)}' cannot be empty.");
        }

        Name = name;
        Surname = surname;
        Email = email;
        Password = password;
    }

    public string Name { get; }
    public string Surname { get; }
    public string Email { get; }
    public string Password { get; }
}