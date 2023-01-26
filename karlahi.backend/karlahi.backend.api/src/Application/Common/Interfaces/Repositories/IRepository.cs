using System.Linq.Expressions;
using KarlArt.Core.Domain.Common;

namespace KarlArt.Core.Application.Common.Interfaces.Repositories;
public interface IRepository<T> where T : IBaseEntity
{
    Task<IList<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<IList<T>> GetListBySearchCriteriaAsync(Expression<Func<T, bool>> searchCriteria);
    Task<T> GetBySearchCriteriaAsync(Expression<Func<T, bool>> searchCriteria);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> AnyAsync(Expression<Func<T, bool>> searchCriteria);
}

