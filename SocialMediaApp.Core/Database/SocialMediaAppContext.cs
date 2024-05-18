using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Core.Models;

namespace SocialMediaApp.Core.Database;

public class SocialMediaAppContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        
        optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Server=127.0.0.1;Port=5432;Database=SocialMediaApp;User Id=postgres;Password=mysecretpassword;");
    }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Post> Posts { get; set; }
}
