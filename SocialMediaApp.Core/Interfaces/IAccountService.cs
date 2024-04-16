using SocialMediaApp.Core.Models;

namespace SocialMediaApp.Core.Interfaces;

public interface IAccountService
{
    public Task AddAccount(Account account);
}