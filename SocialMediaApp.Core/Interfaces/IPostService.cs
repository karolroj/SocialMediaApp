using SocialMediaApp.Core.Contracts;

namespace SocialMediaApp.Core.Interfaces;
public interface IPostService
{
    Task<IEnumerable<PostResponse>> GetPostsAsync();
    Task<PostResponse> GetPostByIdAsync(int id);
    Task<PostResponse> CreatePostAsync(PostRequest post);
    Task<PostResponse> UpdatePostAsync(PostRequest post);
    Task DeletePostAsync(int id);
}
