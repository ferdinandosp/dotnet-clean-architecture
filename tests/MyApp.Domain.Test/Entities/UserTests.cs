using MyApp.Domain.Entities;

namespace MyApp.Domain.Test.Entities;
public class UserTests
{
    [Fact]
    public void SetPassword_SetsPassword()
    {
        // Arrange
        var user = new User();
        var password = "password123";

        // Act
        user.SetPassword(password);

        // Assert
        Assert.NotEqual(user.Password, password);
        Assert.NotEmpty(password);
    }

    [Fact]
    public void VerifyPassword_ReturnsTrueForCorrectPassword()
    {
        // Arrange
        var user = new User();
        var password = "password123";
        user.SetPassword(password);

        // Act
        var result = user.VerifyPassword(password);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void VerifyPassword_ReturnsFalseForIncorrectPassword()
    {
        // Arrange
        var user = new User();
        var password = "password123";
        user.SetPassword(password);

        // Act
        var result = user.VerifyPassword("wrongpassword");

        // Assert
        Assert.False(result);
    }
}
