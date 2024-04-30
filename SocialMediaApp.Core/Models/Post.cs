namespace SocialMediaApp.Core.Models;
public class Post
{
    public Post(string title, string content, int createdBy)
    {
        if (string.IsNullOrEmpty(title))
        {
            throw new ArgumentException($"'{nameof(title)}' cannot be null or empty.", nameof(title));
        }

        if (string.IsNullOrEmpty(content))
        {
            throw new ArgumentException($"'{nameof(content)}' cannot be null or empty.", nameof(content));
        }

        Title = title;
        Content = content;
        CreatedBy = createdBy;
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int CreatedBy { get; set; }
    public virtual Account Account { get; set; } = null!;
}