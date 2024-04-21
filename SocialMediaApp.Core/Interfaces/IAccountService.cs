using SocialMediaApp.Core.Contracts;

namespace SocialMediaApp.Core.Interfaces;

public interface IAccountService
{
    public Task AddAccountAsync(RegisterRequest account);
    Task<string?> GetAccountAsync(LoginRequest request);
}