namespace SocialMediaApp.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        IPostRepository Posts { get; }
        Task SaveAsync();
    }
}