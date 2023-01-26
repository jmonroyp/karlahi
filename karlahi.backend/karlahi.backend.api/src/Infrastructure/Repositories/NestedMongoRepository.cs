using KarlArt.Core.Application.Common.Interfaces.Repositories;
using KarlArt.Core.Domain.Common;
using MongoDB.Driver;

namespace KarlArt.Core.Infrastructure.Repositories;
public abstract class NestedMongoRepository<TParent, TChild> : INestedMongoRepository<TParent, TChild> where TParent : IBaseEntity where TChild : IBaseEntity
{
    protected TParent _parent;
    protected IList<TChild> _subCollection;
    protected IMongoCollection<TParent> _collection;

    public NestedMongoRepository(IMongoDatabase database)
    {
        _parent = default!;
        _subCollection = default!;
        _collection = database.GetCollection<TParent>(typeof(TParent).Name);
    }

    public async Task<INestedRepository<TParent, TChild>> WithRootAsync(Guid id)
    {
        _parent = await _collection.Find<TParent>(entity => entity.Id == id).FirstOrDefaultAsync();
        _subCollection = _parent.GetType().GetProperty(typeof(TChild).Name + "s")?.GetValue(_parent) as IList<TChild> ?? new List<TChild>();
        return this;
    }

    public async Task<TChild> AddAsync(TChild entity)
    {
        _subCollection.Add(entity);
        _parent.GetType().GetProperty(typeof(TChild).Name + "s")?.SetValue(_parent, _subCollection);
        await _collection.ReplaceOneAsync(parent => parent.Id == _parent.Id, _parent);
        return entity;
    }

    public async Task<TChild> UpdateAsync(TChild entity)
    {
        var tChild = _subCollection.FirstOrDefault(x => x.Id == entity.Id);
        if (tChild != null)
        {
            _subCollection.Remove(tChild);
            _subCollection?.Add(entity);
        }
        _parent.GetType().GetProperty(typeof(TChild).Name + "s")?.SetValue(_parent, _subCollection);
        await _collection.ReplaceOneAsync(parent => parent.Id == _parent.Id, _parent);
        return entity;
    }

    public async Task<IList<TChild>> GetAllAsync() =>
        await Task.FromResult(_subCollection);

    public async Task<TChild> GetByIdAsync(Guid id) =>
        await Task.FromResult(_subCollection.FirstOrDefault(x => x.Id == id) ?? default!);
}