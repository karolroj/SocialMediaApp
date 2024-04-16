namespace SocialMediaApp.Core.Contracts;

public record RegisterRequest(string name, string surname, string email, string password, string passwordConfirm);