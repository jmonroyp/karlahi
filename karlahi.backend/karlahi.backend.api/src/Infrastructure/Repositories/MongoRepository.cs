using System.Linq.Expressions;
using KarlArt.Core.Application.Common.Interfaces.Repositories;
using KarlArt.Core.Domain.Common;
using MongoDB.Driver;

namespace KarlArt.Core.Infrastructure.Repositories;
public abstract class MongoRepository<T> : IMongoRepository<T> where T : IBaseEntity
{
    protected IMongoCollection<T> _collection;
    protected FilterDefinitionBuilder<T> _filterBuilder = Builders<T>.Filter;

    public MongoRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<T>(typeof(T).Name);
    }

    public async Task<T> AddAsync(T entity) =>
        await _collection.InsertOneAsync(entity).ContinueWith(task => entity);

    public async Task<IList<T>> GetAllAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<T> GetByIdAsync(Guid id) =>
        await _collection.Find(entity => entity.Id == id).FirstOrDefaultAsync();

    public async Task<IList<T>> GetListBySearchCriteriaAsync(Expression<Func<T, bool>> searchCriteria)
    {
        List<FilterDefinition<T>> filters = new List<FilterDefinition<T>>();
        filters.Add(_filterBuilder.Where(searchCriteria));
        return await _collection.Find(Builders<T>.Filter.And(filters), new FindOptions()
        {
            Collation = new Collation("en_US", strength: CollationStrength.Secondary)
        }).ToListAsync();
    }

    public async Task<T> GetBySearchCriteriaAsync(Expression<Func<T, bool>> searchCriteria)
    {
        List<FilterDefinition<T>> filters = new List<FilterDefinition<T>>();
        filters.Add(_filterBuilder.Where(searchCriteria));
        return await _collection.Find(Builders<T>.Filter.And(filters), new FindOptions()
        {
            Collation = new Collation("en_US", strength: CollationStrength.Secondary)
        }).FirstOrDefaultAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> searchCriteria) =>
        await _collection.Find(searchCriteria).AnyAsync();

    public async Task<T> UpdateAsync(T entity) =>
        await _collection.ReplaceOneAsync(entity => entity.Id == entity.Id, entity).ContinueWith(task => entity);
}
