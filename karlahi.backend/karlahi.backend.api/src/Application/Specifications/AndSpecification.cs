using System.Linq.Expressions;

namespace KarlArt.Core.Application.Specifications;

internal class AndSpecification<T> : GenericSpecification<T>
{
    private GenericSpecification<T> _left;
    private GenericSpecification<T> _right;

    public AndSpecification(GenericSpecification<T> left, GenericSpecification<T> right)
    {
        _left = left;
        _right = right;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = _left.ToExpression();
        var rightExpression = _right.ToExpression();
        return leftExpression.And(rightExpression);;
    }
}