using SocialMediaApp.Core.Contracts;

namespace SocialMediaApp.Core.Interfaces;
public interface IPostService
{
    Task<PostResponse> CreatePostAsync(PostRequest post);
    Task<IEnumerable<PostResponse>> GetPostsAsync();
    Task<PostResponse> GetPostByIdAsync(int id);
    Task<PostResponse> UpdatePostAsync(int postId, PostRequest post);
    Task DeletePostAsync(int id);
}
