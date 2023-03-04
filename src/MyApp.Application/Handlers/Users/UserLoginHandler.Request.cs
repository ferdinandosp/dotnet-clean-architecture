using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Application.Handlers.Users;
public class UserLoginHandlerRequest : IRequest<UserLoginHandlerResponse>
{
    [Required(AllowEmptyStrings = false)]
    public string EmailAddress { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string Password { get; set; }
}
