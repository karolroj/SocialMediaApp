using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Models;

namespace SocialMediaApp.Database;

public class SocialMediaAppContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=SocialMediaApp;User Id=postgres;Password=mysecretpassword;");
    }
    public DbSet<Account> Accounts { get; set; }
}
