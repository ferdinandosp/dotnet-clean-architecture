using MediatR;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities;

namespace MyApp.Application.Handlers.Users;
public class CreateUserHandler : IRequestHandler<CreateUserHandlerRequest, CreateUserHandlerResponse>
{
    private readonly IAppRepository<User> _repository;

    public CreateUserHandler(IAppRepository<User> repository)
    {
        _repository = repository;
    }

    public async Task<CreateUserHandlerResponse> Handle(CreateUserHandlerRequest request, CancellationToken cancellationToken)
    {
        var user = (User)request;

        await _repository.AddAsync(user, cancellationToken);

        return (CreateUserHandlerResponse)user;
    }
}
