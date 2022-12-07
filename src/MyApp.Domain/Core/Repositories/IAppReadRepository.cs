using Ardalis.Specification;
using MyApp.Domain.Core.Models;

namespace MyApp.Domain.Core.Repositories;
public interface IAppReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
