using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Core.Contracts;
using SocialMediaApp.Core.Interfaces;
using SocialMediaApp.Core.Models;

namespace SocialMediaApp.WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        try
        {
            if (request.password != request.passwordConfirm)
                throw new ValidationException("Passwords do not match");

            await _accountService.AddAccountAsync(request);

            return Ok(new { Message = "Account created successfully" });
        }
        catch (Exception ex)
        {
            if (ex is ValidationException || ex is ArgumentException || ex is AccountExcepiton)
            {
                return BadRequest(new { ex.Message });
            }
            else
            {
                // log exception here
                return BadRequest();
            }
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        try
        {
            string? token = await _accountService.GetAccountAsync(request);

            if (string.IsNullOrEmpty(token))
                return Unauthorized();

            return Ok(new { token });
        }
        catch
        {
            // log exception here
            return BadRequest();
        }
    }
}