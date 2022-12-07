using MediatR;

namespace MyApp.Application.Handlers.Users;
public record ValidateUserHandlerRequest(string EmailId,
    string Password) : IRequest<ValidateUserHandlerResponse>;
