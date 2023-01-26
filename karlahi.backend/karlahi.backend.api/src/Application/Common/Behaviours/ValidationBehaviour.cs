using KarlArt.Core.Application.Common.Models;
using FluentValidation;
using MediatR;
using ValidationException = KarlArt.Core.Application.Common.Exceptions.ValidationException;

namespace KarlArt.Core.Application.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _validators.Select(v =>
                    v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();

            if (failures.Any())
            {
                //validate if the response is a Result<T> type
                if (typeof(TResponse).IsGenericType && typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
                {
                    // create a new instance of type Result<T> with the errors
                    var response = Activator.CreateInstance(typeof(TResponse), failures.Select(f => f.ErrorMessage).ToList());

                    return response is not null ? (TResponse)response : throw new ValidationException(failures);
                }
                else
                    throw new ValidationException(failures);
            }
        }
        return await next();
    }
}
