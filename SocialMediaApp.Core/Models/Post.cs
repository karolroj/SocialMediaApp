namespace SocialMediaApp.Core.Models;
public class Post
{
    public Post(string title, string content, int accountId)
    {
        if (string.IsNullOrEmpty(title))
        {
            throw new ArgumentException($"'{nameof(title)}' cannot be null or empty.", nameof(title));
        }

        if (string.IsNullOrEmpty(content))
        {
            throw new ArgumentException($"'{nameof(content)}' cannot be null or empty.", nameof(content));
        }

        if(accountId == 0)
        {
            throw new ArgumentException($"'{nameof(accountId)}' cannot be 0.", nameof(accountId));
        }

        Title = title;
        Content = content;
        AccountId = accountId;
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int AccountId { get; set; }
    public virtual Account Account { get; set; } = null!;
}

public class PostException : Exception
{
    public PostException(string message) : base(message)
    {
    }
}