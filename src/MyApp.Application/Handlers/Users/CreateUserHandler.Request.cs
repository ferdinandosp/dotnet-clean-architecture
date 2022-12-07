using MediatR;
using MyApp.Application.Handlers.Users;
using MyApp.Domain.Enums;

namespace MyApp.Application.Handlers;

public record CreateUserHandlerRequest(string FirstName,
    string LastName,
    string EmailId,
    string Password,
    UserStatus Status) : IRequest<CreateUserHandlerResponse>;
