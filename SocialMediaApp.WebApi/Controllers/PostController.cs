using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Core.Contracts;
using SocialMediaApp.Core.Interfaces;
using SocialMediaApp.Core.Models;

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

    [HttpGet("posts")]
    public async Task<IActionResult> GetPosts()
    {
        try
        {
            var posts = await _postService.GetPostsAsync();
            return Ok(posts);
        }
        catch 
        {
            //log the exception
            return BadRequest("An error occurred while getting the posts");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPostById(int id)
    {
        try
        {
            var updatedPost = await _postService.GetPostByIdAsync(id);
            return Ok(updatedPost);
        }
        catch (Exception ex)
        {
            if (ex is PostException || ex is AccountExcepiton)
            {
                return BadRequest(ex.Message);
            }
            else
            {
                //log the exception
                return BadRequest("An error occurred while getting the post");
            }
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] PostRequest post)
    {
        try
        {
            var createdPost = await _postService.CreatePostAsync(post);
            return Ok(createdPost);
        }
        catch (AccountExcepiton ex)
        {
            return BadRequest(ex.Message);
        }
        catch
        {
            //log the exception
            return BadRequest("An error occurred while creating the post");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePost(int id, [FromBody] PostRequest post)
    {
        try
        {
            var updatedPost = await _postService.UpdatePostAsync(id, post);
            return Ok(updatedPost);
        }
        catch (Exception ex)
        {
            if (ex is PostException || ex is AccountExcepiton)
            {
                return BadRequest(ex.Message);
            }
            else
            {
                //log the exception
                return BadRequest("An error occurred while updating the post");
            }
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        try
        {
            await _postService.DeletePostAsync(id);
            return Ok();
        }
        catch
        {
            //log the exception
            return BadRequest("An error occurred while deleting the post");
        }
    }
}