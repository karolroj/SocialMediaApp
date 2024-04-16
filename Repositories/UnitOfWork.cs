using SocialMediaApp.Database;
using SocialMediaApp.Models;

namespace SocialMediaApp.Repositories;
public class UnitOfWork : IDisposable
{
    private SocialMediaAppContext context = new SocialMediaAppContext();
    private GenericRepository<Account>? accountRepository;

    public GenericRepository<Account> AccountRepository
    {
        get
        {
            if (accountRepository == null)
            {
                accountRepository = new GenericRepository<Account>(context);
            }
            return accountRepository;
        }
    }

    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                context.DisposeAsync();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}