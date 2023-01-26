using System.Linq.Expressions;

namespace KarlArt.Core.Application.Specifications;
public class LuceneQueryParserSpecification<T> : GenericSpecification<T>
{
    private readonly string _searchCriteria;
    private readonly string[] _logicalOperators = new string[] { " AND ", " OR " };

    public LuceneQueryParserSpecification(string searchCriteria, params string[] searchFields)
    {
        _searchCriteria = searchCriteria;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        foreach (var op in _logicalOperators)
        {
            if (_searchCriteria.Contains(op))
            {
                var left = _searchCriteria.Split(op)[0];
                var right = _searchCriteria.Split(op)[1];
                var leftSpecification = new ExpressionSpecification<T>(left);
                var rightSpecification = new ExpressionSpecification<T>(right);
                if (op == " AND ")
                    return new AndSpecification<T>(leftSpecification, rightSpecification).ToExpression();
                else if (op == " OR ")
                    return new OrSpecification<T>(leftSpecification, rightSpecification).ToExpression();
            }
        }
        return new ExpressionSpecification<T>(_searchCriteria).ToExpression();
    } 
}