﻿using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Handlers;
using MyApp.Application.Handlers.Users;

namespace MyApp.WebApi.Controllers.Users;

[ApiVersion( 1.0 )]
[ApiController]
[Route("api/user")]
public class Create : ControllerBase
{
    private readonly IMediator _mediator;

    public Create(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateUserHandlerResponse>> CreateUser(CreateUserHandlerRequest req, CancellationToken cancellation)
    {
        Console.WriteLine("This is from V1 API.");
        var result = await _mediator.Send(req, cancellation);
        return Ok(result);
    }
}
