namespace SocialMediaApp.Contracts;

public record RegisterRequest(string name, string surname, string email, string password, string passwordConfirm);