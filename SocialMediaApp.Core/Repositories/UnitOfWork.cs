using SocialMediaApp.Core.Database;
using SocialMediaApp.Core.Interfaces;

namespace SocialMediaApp.Core.Repositories;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly SocialMediaAppContext _context;
    public IAccountRepository Accounts { get; private set; }
    public IPostRepository Posts { get; private set; }

    public UnitOfWork(SocialMediaAppContext context)
    {
        _context = context;
        Accounts = new AccountRepository(_context);
        Posts = new PostRepository(_context);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}