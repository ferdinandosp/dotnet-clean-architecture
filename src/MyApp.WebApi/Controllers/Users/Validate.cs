using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Handlers.Users;

namespace MyApp.WebApi.Controllers.Users;

[ApiController]
[Route("api/user/validate")]
public class Validate : Controller
{
    private readonly IMediator _mediator;

    public Validate(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<ValidateUserHandlerResponse>> ValidateUser(ValidateUserHandlerRequest req, CancellationToken cancellation)
    {
        var result = await _mediator.Send(req, cancellation);
        return Ok(result);
    }
}
