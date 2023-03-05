using Ardalis.Specification;
using MediatR;
using Moq;
using MyApp.Application.Handlers.Users;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities;
using MyApp.Domain.Specifications.Users;

namespace MyApp.Application.Test.Handlers.Users;
public class UserLoginHandlerTests
{
    private readonly Mock<IAppReadRepository<User>> _repositoryMock;
    private readonly Mock<IMediator> _mediatorMock;
    private readonly UserLoginHandler _handler;

    public UserLoginHandlerTests()
    {
        _repositoryMock = new Mock<IAppReadRepository<User>>();
        _mediatorMock = new Mock<IMediator>();
        _handler = new UserLoginHandler(_repositoryMock.Object, _mediatorMock.Object);
    }

    [Fact]
    public async Task Handle_WhenUserExistsAndPasswordMatches_ReturnsToken()
    {
        // Arrange
        var request = new UserLoginHandlerRequest { EmailAddress = "test@test.com", Password = "password" };
        var user = new User { Id = Guid.NewGuid(), EmailAddress = request.EmailAddress };
        user.SetPassword(request.Password);
        _repositoryMock.Setup(x => x.SingleOrDefaultAsync(It.IsAny<GetUserByEmailSpec>(), default)).ReturnsAsync(user);
        var generateTokenHandlerRequest = new GenerateTokenHandlerRequest(user.Id, user.EmailAddress, user.Role);
        var loginToken = new GenerateTokenHandlerResponse("token");
        _mediatorMock.Setup(x => x.Send(generateTokenHandlerRequest, default)).ReturnsAsync(loginToken);

        // Act
        var result = await _handler.Handle(request, default);

        // Assert
        Assert.Equal(loginToken.Token, result.Token);
    }

    [Fact]
    public async Task Handle_WhenUserDoesNotExist_ThrowsException()
    {
        // Arrange
        var request = new UserLoginHandlerRequest { EmailAddress = "test@test.com", Password = "password" };
        _repositoryMock.Setup(x => x.SingleOrDefaultAsync(It.IsAny<GetUserByEmailSpec>(), default)).ReturnsAsync((User)null);

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _handler.Handle(request, default));
    }

    [Fact]
    public async Task Handle_WhenPasswordDoesNotMatch_ThrowsException()
    {
        // Arrange
        var request = new UserLoginHandlerRequest { EmailAddress = "test@test.com", Password = "password" };
        var user = new User { Id = Guid.NewGuid(), EmailAddress = request.EmailAddress };
        user.SetPassword("differentpassword");
        _repositoryMock.Setup(x => x.SingleOrDefaultAsync(It.IsAny<GetUserByEmailSpec>(), default)).ReturnsAsync(user);

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _handler.Handle(request, default));
    }
}
