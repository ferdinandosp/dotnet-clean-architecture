using Ardalis.Specification;
using MyApp.Domain.Core.Models;

namespace MyApp.Domain.Core.Repositories;
public interface IAppRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
