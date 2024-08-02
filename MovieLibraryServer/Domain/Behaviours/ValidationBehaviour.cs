using FluentValidation;
using MediatR;

namespace MovieLibraryServer.Domain.Behaviours;

public class ValidationBehaviour<TRequest, TResposne>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResposne> where TRequest : notnull
{
    public async Task<TResposne> Handle(TRequest request, RequestHandlerDelegate<TResposne> next, CancellationToken cancellationToken)
    {
        if (!validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);
        var errorsDictionary = validators.Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x is not null)
            .GroupBy(x => x.PropertyName.Substring(x.PropertyName.IndexOf('.') + 1),
                x => x.ErrorMessage, (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                }
            ).ToDictionary(x=> x.Key, x=>x.Values);
        if (errorsDictionary.Count != 0)
        {
            throw new Exceptions.ValidationException(errorsDictionary);
        }

        return await next();
    }
}