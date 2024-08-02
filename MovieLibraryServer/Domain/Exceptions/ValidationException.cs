namespace MovieLibraryServer.Domain.Exceptions;

public class ValidationException(IReadOnlyDictionary<string, string[]> errors)
    : Exception("One or more validation errors occured")
{
    public IReadOnlyDictionary<string,string[]> Errors { get; } = errors;
}