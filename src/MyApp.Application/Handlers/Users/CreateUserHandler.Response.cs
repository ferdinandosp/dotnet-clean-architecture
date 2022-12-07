using MyApp.Domain.Enums;

namespace MyApp.Application.Handlers.Users;

public record CreateUserHandlerResponse(string FirstName,
    string LastName,
    string EmailId,
    string Password,
    UserStatus Status);
