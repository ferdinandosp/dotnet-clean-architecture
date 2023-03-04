using MediatR;
using MyApp.Domain.Enums;

namespace MyApp.Application.Handlers.Users;

public record GenerateTokenHandlerRequest(
    Guid UserId,
    string EmailAddress,
    UserRole UserRole,
    int ExpiryInMinutes = 30) : IRequest<GenerateTokenHandlerResponse>;