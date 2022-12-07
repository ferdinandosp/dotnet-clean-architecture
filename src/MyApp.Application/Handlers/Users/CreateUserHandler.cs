using AutoMapper;
using MediatR;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities;

namespace MyApp.Application.Handlers.Users;
public class CreateUserHandler : IRequestHandler<CreateUserHandlerRequest, CreateUserHandlerResponse>
{
    private readonly IAppRepository<User> _repository;
    private readonly IMapper _mapper;

    public CreateUserHandler(IAppRepository<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateUserHandlerResponse> Handle(CreateUserHandlerRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);

        await _repository.AddAsync(user, cancellationToken);

        return _mapper.Map<CreateUserHandlerResponse>(user);
    }
}
