using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace KarlaHi.Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Where { get; }
        List<Expression<Func<T, object>>> Includes { get; }
    }
}