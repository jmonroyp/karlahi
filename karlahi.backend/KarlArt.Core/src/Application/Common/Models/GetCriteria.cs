using System.Linq.Expressions;
using KarlArt.Core.Application.Common.Interfaces.Models;
using KarlArt.Core.Application.Specifications;

namespace KarlArt.Core.Application.Common.Models;
public abstract class GetCriteria<T>
{
    private readonly IGetQueryString _getQueryString;
    public GetCriteria()
    {
        _getQueryString = default!;
    }
    
    public GetCriteria(IGetQueryString getQueryString)
    {
        _getQueryString = getQueryString;
    }

    public Expression<Func<T, bool>> ToExpression() =>
         !string.IsNullOrEmpty(_getQueryString.Q) ? 
         new LuceneQueryParserSpecification<T>(_getQueryString.Q).ToExpression() :
         new ExpressionSpecification<T>(x => true).CurrentExpression;

    // method to parse Expression<Func<T, bool>> to Expression<Func<TDestination, bool>> 
    public Expression<Func<TDestination, bool>> ToExpression<TDestination>()
    {
        var expression = ToExpression();
        var param = Expression.Parameter(typeof(TDestination), "x");
        return Expression.Lambda<Func<TDestination, bool>>(expression.Body, param);
    }
}