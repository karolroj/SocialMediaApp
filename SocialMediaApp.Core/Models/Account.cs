using System.ComponentModel.DataAnnotations;

namespace SocialMediaApp.Core.Models;

public class Account
{
    public Account(string name, string surname, string email, string password, byte[] salt)
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
        Salt = salt;
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
    [Required]
    public byte[] Salt { get; set; }
    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}   

public class AccountExcepiton : Exception
{
    public AccountExcepiton(string message) : base(message)
    {
    }
}