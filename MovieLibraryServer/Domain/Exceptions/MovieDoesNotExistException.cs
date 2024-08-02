namespace MovieLibraryServer.Domain.Exceptions;

public class MovieDoesNotExistException(string? message) : Exception(message)
{
    public override string Message { get; } = message!;

    public MovieDoesNotExistException()
        : this(null)
    {
        Message = "Movie does not exist";
    }
}
