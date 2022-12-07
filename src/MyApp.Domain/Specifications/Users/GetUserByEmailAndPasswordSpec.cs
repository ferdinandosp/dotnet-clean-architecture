using Ardalis.Specification;
using MyApp.Domain.Entities;

namespace MyApp.Domain.Specifications.Users;
public class GetUserByEmailAndPasswordSpec : Specification<User>, ISingleResultSpecification<User>
{
    public GetUserByEmailAndPasswordSpec(string emailId, string password)
    {
        Query.Where(x => x.EmailId == emailId && x.Password == password);
    }
}
