using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Handlers.Users;

namespace MyApp.WebApi.Controllers.Users;

[ApiVersion(1.0)]
[ApiController]
[Route("api/user/login")]
public class Login : ControllerBase
{
    private readonly IMediator _mediator;

    public Login(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<UserLoginHandlerResponse>> UserLogin(
        UserLoginHandlerRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);

        return Ok(result);
    }
}
