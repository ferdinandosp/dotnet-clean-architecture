using MyApp.Domain.Helpers;

namespace MyApp.Domain.Test.Helpers;
public class PasswordHasherTests
{
    [Fact]
    public void HashedPassword_VerifiesCorrectly()
    {
        // Arrange
        var password = "myPassword";
        var hashedPassword = PasswordHasher.HashPassword(password);

        // Act
        var result = PasswordHasher.VerifyPassword(password, hashedPassword);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HashedPassword_VerifiesCorrectly_NotVerified()
    {
        // Arrange
        var password = "myPassword";
        var hashedPassword = PasswordHasher.HashPassword(password);

        // Act
        var result = PasswordHasher.VerifyPassword("wrongPassword", hashedPassword);

        // Assert
        Assert.False(result);
    }
}
