using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Test.Infraestructure.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Where { get; }
        List<Expression<Func<T, object>>> Includes { get; }
    }
}