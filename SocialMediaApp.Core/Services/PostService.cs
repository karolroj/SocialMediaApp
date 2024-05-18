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
        var user = await _unitOfWork.Accounts.GetByIdAsync(request.AccountId);
        if (user == null)
            throw new AccountExcepiton("User not found in post creation");

        var post = new Post(request.Title, request.Content, request.AccountId);
        await _unitOfWork.Posts.InsertAsync(post);
        await _unitOfWork.SaveAsync();

        return new PostResponse(post.Id, post.Title, post.Content, $"{user.Name} {user.Surname}");
    }

    public async Task<IEnumerable<PostResponse>> GetPostsAsync()
    {
        IEnumerable<Post> posts = await _unitOfWork.Posts.GetAsync();
        return posts.Select(p => new PostResponse(p.Id, p.Title, p.Content, $"{p.Account.Name} {p.Account.Surname}"));
    }

    public async Task<PostResponse> GetPostByIdAsync(int id)
    {
        var post = await _unitOfWork.Posts.GetByIdAsync(id);

        if (post == null)
            throw new PostException("Post not found");

        return new PostResponse(post.Id, post.Title, post.Content, $"{post.Account.Name} {post.Account.Surname}");
    }

    public async Task<PostResponse> UpdatePostAsync(int id, PostRequest request)
    {
        var post = await _unitOfWork.Posts.GetByIdAsync(id);
        if (post == null)
            throw new PostException("Post not found");

        post.Title = request.Title;
        post.Content = request.Content;
        post.AccountId = request.AccountId;

        _unitOfWork.Posts.Update(post);
        await _unitOfWork.SaveAsync();

        return new PostResponse(post.Id, post.Title, post.Content, $"{post.Account.Name} {post.Account.Surname}");
    }

    public async Task DeletePostAsync(int id)
    {
        await _unitOfWork.Posts.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
    }
}