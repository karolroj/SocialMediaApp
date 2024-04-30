using SocialMediaApp.Core.Contracts;
using SocialMediaApp.Core.Interfaces;
using SocialMediaApp.Core.Models;

namespace SocialMediaApp.Core.Services;

public class PostService : IPostService
{
    private readonly IUnitOfWork _unitOfWork;
    public PostService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<PostResponse> CreatePostAsync(PostRequest request)
    {
        throw new NotImplementedException();
    }

    public Task DeletePostAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PostResponse> GetPostByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PostResponse>> GetPostsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PostResponse> UpdatePostAsync(PostRequest request)
    {
        throw new NotImplementedException();
    }
}