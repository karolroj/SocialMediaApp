using SocialMediaApp.Core.Database;
using SocialMediaApp.Core.Interfaces;
using SocialMediaApp.Core.Models;

namespace SocialMediaApp.Core.Repositories;
public class AccountRepository : GenericRepository<Account>, IAccountRepository
{
    public AccountRepository(SocialMediaAppContext context) : base(context) { }
}