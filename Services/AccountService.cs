using SocialMediaApp.Database;
using SocialMediaApp.Interfaces;
using SocialMediaApp.Models;
using SocialMediaApp.Repositories;

namespace SocialMediaApp.Services;

public class AccountService : IAccountService
{
    private UnitOfWork _unitOfWork = new UnitOfWork();
    public AccountService() { }
    public async Task AddAccount(Account account)
    {
        await _unitOfWork.AccountRepository.InsertAsync(account);
        await _unitOfWork.SaveAsync();
    }
}