namespace SocialMediaApp.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        Task SaveAsync();
    }
}