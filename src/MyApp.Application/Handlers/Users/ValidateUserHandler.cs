using AutoMapper;
using MediatR;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities;
using MyApp.Domain.Specifications.Users;

namespace MyApp.Application.Handlers.Users;
public class ValidateUserHandler : IRequestHandler<ValidateUserHandlerRequest, ValidateUserHandlerResponse>
{
    private readonly IAppReadRepository<User> _repository;
    private readonly IMapper _mapper;

    public ValidateUserHandler(IAppReadRepository<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ValidateUserHandlerResponse> Handle(ValidateUserHandlerRequest request, CancellationToken cancellationToken)
    {
        var spec = new GetUserByEmailAndPasswordSpec(request.EmailId, request.Password);
        var user = await _repository.SingleOrDefaultAsync(spec, cancellationToken);

        return _mapper.Map<ValidateUserHandlerResponse>(user);
    }
}
