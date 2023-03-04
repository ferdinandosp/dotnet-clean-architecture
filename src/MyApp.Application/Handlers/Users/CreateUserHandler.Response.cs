using MyApp.Domain.Entities;
using MyApp.Domain.Enums;

namespace MyApp.Application.Handlers.Users;

public class CreateUserHandlerResponse
{
    public Guid Id { get; set; }
    public string EmailAddress { get; set; }
    public UserStatus Status { get; set; }

    public static explicit operator CreateUserHandlerResponse(User user)
    {
        return new CreateUserHandlerResponse
        {
            Id = user.Id,
            EmailAddress = user.EmailAddress,
            Status = user.Status
        };
    }
}
