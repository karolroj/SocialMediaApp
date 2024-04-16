using Microsoft.EntityFrameworkCore;

namespace SocialMediaApp.Database;

public class SocialMediaAppContext : DbContext
{
    public SocialMediaAppContext(DbContextOptions options) : base(options) { }
}
