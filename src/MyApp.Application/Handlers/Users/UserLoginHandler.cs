using MediatR;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities;
using MyApp.Domain.Specifications.Users;

namespace MyApp.Application.Handlers.Users;
public class UserLoginHandler
    : IRequestHandler<UserLoginHandlerRequest, UserLoginHandlerResponse>
{
    private readonly IAppReadRepository<User> _repository;
    private readonly IMediator _mediator;

    public UserLoginHandler(IAppReadRepository<User> repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<UserLoginHandlerResponse> Handle(UserLoginHandlerRequest request, CancellationToken cancellationToken)
    {
        var spec = new GetUserByEmailSpec(request.EmailAddress);
        var user = await _repository.SingleOrDefaultAsync(spec, cancellationToken);

        if ( user == null || !user.VerifyPassword(request.Password))
        {
            throw new Exception("Invalid password.");
        }

        var generateTokenHandlerRequest = new GenerateTokenHandlerRequest(
            user.Id,
            user.EmailAddress,
            user.Role);
        var loginToken = await _mediator.Send(generateTokenHandlerRequest, cancellationToken);

        return new UserLoginHandlerResponse { Token = loginToken.Token };
    }
}
