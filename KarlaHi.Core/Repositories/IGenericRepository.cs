using System.Collections.Generic;
using System.Threading.Tasks;
using KarlaHi.Core.Specifications;
using KarlaHi.Infrastructure.Entities;

namespace KarlaHi.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();     
        Task<T> GetWithSpecAsync(ISpecification<T> specification);
        Task<List<T>> GetAllWithSpecAsync(ISpecification<T> specification);
    }
}