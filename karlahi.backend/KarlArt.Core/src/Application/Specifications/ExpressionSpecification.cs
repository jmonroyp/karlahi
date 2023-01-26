using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace KarlArt.Core.Application.Specifications;
public class ExpressionSpecification<T> : GenericSpecification<T>
{
    private readonly string _expression;

    public ExpressionSpecification(string expression)
    {
        _expression = expression;
    }

    public ExpressionSpecification(Expression<Func<T, bool>> expression)
    {
        _expression = expression.ToString();
        _currentExpression = expression;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var (fieldOperator, keyValue) = GetFieldOperatorAndKeyValue(_expression);

        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, keyValue.Key);
        var constant = Expression.Constant(keyValue.Value);
        var body = GetExpression(fieldOperator, property, constant);
        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }

    private Expression GetExpression(FieldOperator fieldOperator, Expression property, Expression constant)
    {
        switch (fieldOperator)
        {
            case FieldOperator.Equal:
                if (property.Type == typeof(string))
                    return Expression.Call(property, typeof(string).GetMethod("Contains", new[] { typeof(string) })!, constant);
                else if (property.Type == typeof(bool)) 
                {
                    // get keyValue object
                    var converter = TypeDescriptor.GetConverter(typeof(bool));
                    var value = bool.Parse(converter.ConvertFromInvariantString(constant.ToString().Replace("\"", string.Empty))!.ToString() ?? string.Empty);
                    return Expression.Equal(property, Expression.Constant((object)value));
                }
                else
                    return Expression.Equal(property, constant);
            case FieldOperator.GreaterThan:
                return Expression.GreaterThan(property, constant);
            case FieldOperator.LessThan:
                return Expression.LessThan(property, constant);
            case FieldOperator.GreaterThanOrEqual:
                return Expression.GreaterThanOrEqual(property, constant);
            case FieldOperator.LessThanOrEqual:
                return Expression.LessThanOrEqual(property, constant);
            case FieldOperator.NotEqual:
                return Expression.NotEqual(property, constant);
            default:
                return Expression.Equal(property, constant);
        }
    }
}
