using MediatR;
using MyApp.Application.Handlers.Users;
using MyApp.Domain.Entities;
using MyApp.Domain.Enums;

namespace MyApp.Application.Handlers;

public class CreateUserHandlerRequest : IRequest<CreateUserHandlerResponse>
{
    public string EmailAddress { get; init; }
    public string Password { get; init; }
    public UserStatus Status { get; init; }
    public UserRole Role { get; init; }

    public static implicit operator User(CreateUserHandlerRequest request)
    {
        var user = new User
        {
            EmailAddress = request.EmailAddress,
            Status = request.Status,
            Role = request.Role
        };

        // have to manually set password because it will be hashed.
        user.SetPassword(request.Password);

        return user;
    }
}
