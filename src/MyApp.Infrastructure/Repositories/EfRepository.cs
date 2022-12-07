using Ardalis.Specification.EntityFrameworkCore;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Repositories;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure.Repositories;
public class EfRepository<T> : RepositoryBase<T>, IAppReadRepository<T>, IAppRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(MyAppDbContext dbContext) : base(dbContext)
    {
    }
}
