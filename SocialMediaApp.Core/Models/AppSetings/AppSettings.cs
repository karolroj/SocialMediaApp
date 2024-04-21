namespace SocialMediaApp.Core.Models.AppSettings;
public class AppSettings
{
    public JwtSettings Jwt { get; set; } = new();
}