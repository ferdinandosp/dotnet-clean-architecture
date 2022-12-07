using Ardalis.Specification;
using MyApp.Domain.Entities;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Specifications.Users;

public class GetAllActiveUsersSpec : Specification<User>
{
    public GetAllActiveUsersSpec()
    {
        Query.Where(x => x.Status == UserStatus.Active);
    }
}
