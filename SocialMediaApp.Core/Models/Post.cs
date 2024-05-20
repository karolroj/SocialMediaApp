namespace SocialMediaApp.Core.Models;
public class Post
{
    public Post(string title, string content, int accountId)
    {
        if (string.IsNullOrEmpty(title))
        {
            throw new ArgumentException("Title cannot be null or empty");
        }

        if (string.IsNullOrEmpty(content))
        {
            throw new ArgumentException("Content cannot be null or empty");
        }

        if (accountId == 0)
        {
            throw new ArgumentException("Account id cannot be 0");
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