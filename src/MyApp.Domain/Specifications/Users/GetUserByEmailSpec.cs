using Ardalis.Specification;
using MyApp.Domain.Entities;

namespace MyApp.Domain.Specifications.Users;
public class GetUserByEmailSpec : Specification<User>, ISingleResultSpecification<User>
{
    public GetUserByEmailSpec(string emailId)
    {
        Query.Where(x => x.EmailAddress == emailId);
    }
}
