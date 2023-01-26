using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KarlArt.Core.Application.Specifications;
public class NotSpecification<T> : GenericSpecification<T>
{
    private readonly GenericSpecification<T> _specification;

    public NotSpecification(GenericSpecification<T> specification)
    {
        _specification = specification;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var expression = _specification.ToExpression();
        return expression.Not();
    }
}