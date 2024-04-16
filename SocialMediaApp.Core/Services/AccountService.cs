using SocialMediaApp.Core.Database;
using SocialMediaApp.Core.Interfaces;
using SocialMediaApp.Core.Models;
using SocialMediaApp.Core.Repositories;

namespace SocialMediaApp.Core.Services;

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