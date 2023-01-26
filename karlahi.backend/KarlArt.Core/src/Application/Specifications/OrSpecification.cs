using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KarlArt.Core.Application.Specifications;
public class OrSpecification<T> : GenericSpecification<T>
{
    private GenericSpecification<T> _left;
    private GenericSpecification<T> _right;

    public OrSpecification(GenericSpecification<T> left, GenericSpecification<T> right)
    {
        _left = left;
        _right = right;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = _left.ToExpression();
        var rightExpression = _right.ToExpression();

        return leftExpression.Or(rightExpression);
    }
}