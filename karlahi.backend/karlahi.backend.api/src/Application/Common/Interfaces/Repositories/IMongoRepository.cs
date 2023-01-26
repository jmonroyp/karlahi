using KarlArt.Core.Domain.Common;

namespace KarlArt.Core.Application.Common.Interfaces.Repositories;
public interface IMongoRepository<T> : IRepository<T> where T : IBaseEntity
{
}