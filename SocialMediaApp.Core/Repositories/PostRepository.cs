
using SocialMediaApp.Core.Database;
using SocialMediaApp.Core.Interfaces;
using SocialMediaApp.Core.Models;

namespace SocialMediaApp.Core.Repositories;
public class PostRepository : GenericRepository<Post>, IPostRepository 
{
    public PostRepository(SocialMediaAppContext context) : base(context) { }
}