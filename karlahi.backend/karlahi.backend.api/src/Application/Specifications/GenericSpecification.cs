using System.Linq.Expressions;

namespace KarlArt.Core.Application.Specifications;
public abstract class GenericSpecification<T>
{
    public abstract Expression<Func<T, bool>> ToExpression();

    protected Expression<Func<T, bool>> _currentExpression = null!;
    public Expression<Func<T, bool>> CurrentExpression
    {
        get
        {
            if (_currentExpression == null)
                _currentExpression = ToExpression();
            return _currentExpression;
        }
    }
    protected readonly string[] _fieldOperators = new string[] { ":", ">", "<", ">=", "<=", " not " };

    public (FieldOperator, KeyValuePair<string, string>) GetFieldOperatorAndKeyValue(string fieldQuery)
    {
        var fieldOperator = FieldOperator.Equal;
        string key = string.Empty;
        string value = string.Empty;
        foreach (var op in _fieldOperators)
        {
            if (fieldQuery.Contains(op))
            {
                key = fieldQuery.Split(op)[0];
                value = fieldQuery.Split(op)[1];
                switch (op)
                {
                    case ":":
                        fieldOperator = FieldOperator.Equal;
                        break;
                    case ">":
                        fieldOperator = FieldOperator.GreaterThan;
                        break;
                    case "<":
                        fieldOperator = FieldOperator.LessThan;
                        break;
                    case ">=":
                        fieldOperator = FieldOperator.GreaterThanOrEqual;
                        break;
                    case "<=":
                        fieldOperator = FieldOperator.LessThanOrEqual;
                        break;
                    case " not ":
                        fieldOperator = FieldOperator.NotEqual;
                        break;
                }
                break;
            }
        }
        return (fieldOperator, new KeyValuePair<string, string>(key, value.Replace("\"", "")));
    }
}

public class ParameterReplacer : ExpressionVisitor
{
    private Expression _from, _to;

    public ParameterReplacer(Expression from, Expression to)
    {
        _from = from;
        _to = to;
    }

    public ParameterReplacer(Expression to) : this(null!, to) { }

    public Expression Replace(Expression expression)
    {
        return Visit(expression);
    }

    public Expression Replace(Expression from, Expression to)
    {
        _from = from;
        _to = to;
        return Visit(from);
    }
}

public enum FieldOperator
{
    Equal,
    GreaterThan,
    LessThan,
    GreaterThanOrEqual,
    LessThanOrEqual,
    NotEqual
}
