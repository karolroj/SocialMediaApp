using System.ComponentModel.DataAnnotations;

namespace SocialMediaApp.Models;

public class Account
{
    public Account(string name, string surname, string email, string password)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.");
        }

        if (string.IsNullOrEmpty(surname))
        {
            throw new ArgumentException($"'{nameof(surname)}' cannot be null or empty.");
        }

        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException($"'{nameof(email)}' cannot be null or empty.");
        }

        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException($"'{nameof(password)}' cannot be null or empty.");
        }

        Name = name;
        Surname = surname;
        Email = email;
        Password = password;
    }

    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}