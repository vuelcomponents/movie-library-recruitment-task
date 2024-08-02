namespace MovieLibraryServer.Domain.Exceptions;

public class ExternalMovieLibraryRequestException(string? message) : Exception(message)
{
    public override string Message { get; } = message!;

    public ExternalMovieLibraryRequestException()
        : this(null)
    {
        Message = "Request to external API has not been accomplished successfully ";
    }
}
