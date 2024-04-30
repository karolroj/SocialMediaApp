namespace SocialMediaApp.Core.Contracts;
public record PostResponse (string Title, string Content, string CreatedBy, DateTime CreatedOn, DateTime UpdatedOn);