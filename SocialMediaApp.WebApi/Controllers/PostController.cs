using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Core.Contracts;
using SocialMediaApp.Core.Interfaces;

namespace SocialMediaApp.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;
    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPosts()
    {
        var posts = await _postService.GetPostsAsync();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostById(int id)
    {
        var post = await _postService.GetPostByIdAsync(id);
        return Ok(post);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] PostRequest post)
    {
        var createdPost = await _postService.CreatePostAsync(post);
        return Ok(createdPost);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePost([FromBody] PostRequest post)
    {
        var updatedPost = await _postService.UpdatePostAsync(post);
        return Ok(updatedPost);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        await _postService.DeletePostAsync(id);
        return Ok();
    }
}