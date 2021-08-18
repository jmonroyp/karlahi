using System.Linq;
using KarlaHi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace KarlaHi.Core.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec) 
        {
            var query = inputQuery;

            if (spec.Where != null) {
                query = query.Where(spec.Where);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}