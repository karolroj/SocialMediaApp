using SocialMediaApp.Core.Contracts;
using SocialMediaApp.Core.Interfaces;
using SocialMediaApp.Core.Models;
using SocialMediaApp.Core.Utilities;

namespace SocialMediaApp.Core.Services;

public class AccountService : IAccountService
{
    private readonly IUnitOfWork _unitOfWork; 
    private readonly ITokenService _tokenService;

    public AccountService(ITokenService tokenService, IUnitOfWork unitOfWork)
    {
        _tokenService = tokenService;
        _unitOfWork = unitOfWork;
    }

    public async Task AddAccountAsync(RegisterRequest request)
    {
        var securedPassword = PasswordUtilities.HashPasword(request.password, out var salt);

        Account account = new(request.name, request.surname, request.email, securedPassword, salt);

        await _unitOfWork.Accounts.InsertAsync(account);
        await _unitOfWork.SaveAsync();
    }

    public async Task<string?> GetAccountAsync(LoginRequest request)
    {
        Account? account = await _unitOfWork.Accounts.GetAsync(a => a.Email == request.email);
        if (account == null)
            return null;

        if (!PasswordUtilities.VerifyPassword(request.password, account.Password, account.Salt))
            return null;

        return _tokenService.GenerateToken();
    }
}