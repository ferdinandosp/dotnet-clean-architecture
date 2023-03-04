using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Handlers.Users;
using MyApp.Application.Handlers;

namespace MyApp.WebApi.Controllers.Users;

[ApiVersion( 2.0 )]
[ApiController]
[Route("api/user")]
public class CreateV2 : ControllerBase
{
    private readonly IMediator _mediator;

    public CreateV2(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateUserHandlerResponse>> CreateUser(CreateUserHandlerRequest req, CancellationToken cancellation)
    {
        Console.WriteLine("This is from V2 API.");
        var result = await _mediator.Send(req, cancellation);
        return Ok(result);
    }
}
