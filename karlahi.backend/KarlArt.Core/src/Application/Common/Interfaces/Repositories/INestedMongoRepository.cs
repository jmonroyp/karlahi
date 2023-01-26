using KarlArt.Core.Domain.Common;

namespace KarlArt.Core.Application.Common.Interfaces.Repositories;
public interface INestedRepository<TParent, TChild> where TParent : IBaseEntity where TChild : IBaseEntity
{
    Task<IList<TChild>> GetAllAsync();
    Task<TChild> GetByIdAsync(Guid id);
    Task<TChild> AddAsync(TChild entity);
    Task<TChild> UpdateAsync(TChild entity);
    Task<INestedRepository<TParent, TChild>> WithRootAsync(Guid id);
}

public interface INestedMongoRepository<TParent, TChild> : INestedRepository<TParent, TChild> where TParent : IBaseEntity where TChild : IBaseEntity
{
    // Task<IList<TChild>> GetAllAsync();
    // Task<TChild> GetByIdAsync(Guid id);
    // Task<TChild> AddAsync(TChild entity);
    // Task<TChild> UpdateAsync(TChild entity);
}