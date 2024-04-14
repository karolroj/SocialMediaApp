using SocialMediaApp.Models;

namespace SocialMediaApp.Interfaces;

public interface IAccountService
{
    public Task AddAccount(Account account);
}