using Microsoft.AspNetCore.Mvc;
using Moq;
using SocialMediaApp.Core.Contracts;
using SocialMediaApp.Core.Interfaces;
using SocialMediaApp.WebApi.Controllers;

namespace SocialMediaApp.Tests.ControllersTests;
public class AccountControllerTests
{
    private readonly Mock<IAccountService> _accountServiceMock;
    private readonly AccountController _accountController;

    public AccountControllerTests()
    {
        _accountServiceMock = new Mock<IAccountService>();
        _accountController = new AccountController(_accountServiceMock.Object);
    }

    [Fact]
    public async Task Register_WhenPasswordsDoNotMatch_ShouldReturnBadRequest()
    {
        // Arrange
        var request = new RegisterRequest("John", "Doe", "JohnDoe@test.com", "password", "password1");

        // Act
        var result = await _accountController.Register(request);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("passwords do not match.", (result as BadRequestObjectResult)?.Value);
    }

    [Theory]
    [InlineData("John", "Doe", "", "password", "password")]
    [InlineData("John", "", "JohnDoe@test.com", "password", "password")]
    [InlineData("", "Doe", "JohnDoe@test.com", "password", "password")]
    public async Task Register_WhenRequestIsInvalid_ShouldReturnBadRequest(string firstName, string lastName, string email, string password, string confirmPassword)
    {
        // Arrange
        var request = new RegisterRequest(firstName, lastName, email, password, confirmPassword);

        // Act
        var result = await _accountController.Register(request);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
        Assert.Contains("cannot be null or empty", (result as BadRequestObjectResult)?.Value?.ToString());
    }
}
