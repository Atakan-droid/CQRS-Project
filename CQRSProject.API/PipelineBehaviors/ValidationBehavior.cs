using System.ComponentModel.DataAnnotations;
using FluentValidation;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace CQRSProject.API.PipelineBehaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        //pre
        var failures = _validators
            .Select(x => x.Validate(request))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .ToList();
        if (failures.Any())
        {
            throw new ValidationException(failures);
        }

        return await next();
    }
}