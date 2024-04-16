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
                throw new ValidationException("passwords do not match.");

            Account account = new(request.name, request.surname, request.email, request.password);

            await _accountService.AddAccount(account);

            return Ok();
        }
        catch (Exception ex)
        {
            if (ex is ValidationException || ex is ArgumentException)
            {
                return BadRequest(ex.Message);
            }
            else
            {
                // log exception here
                return BadRequest();
            }
        }
    }
}