namespace MyApp.Application.Handlers.Users;
public record ValidateUserHandlerResponse(Guid Id,
    string FirstName,
    string LastName);
