using Moq;
using SocialMediaApp.Core.Contracts;
using SocialMediaApp.Core.Interfaces;
using SocialMediaApp.Core.Services;

namespace SocialMediaApp.Tests.ServicesTests;
public class AccountServiceTests
{
    private readonly Mock<ITokenService> _tokenServiceMock;
    private readonly AccountService _accountService;

    public AccountServiceTests()
    {
        _tokenServiceMock = new Mock<ITokenService>();
        _accountService = new AccountService(_tokenServiceMock.Object);
    }

    [Theory]
    [InlineData("John", "Doe", "", "password", "password")]
    [InlineData("John", "", "JohnDoe@test.com", "password", "password")]
    [InlineData("", "Doe", "JohnDoe@test.com", "password", "password")]
    public async Task Register_WhenRequestIsInvalid_ShouldReturnBadRequest(string firstName, string lastName, string email, string password, string confirmPassword)
    {
        // Arrange
        var request = new RegisterRequest(firstName, lastName, email, password, confirmPassword);

        // Assert
        await Assert.ThrowsAsync<ArgumentException>(() => _accountService.AddAccountAsync(request));
    }
}