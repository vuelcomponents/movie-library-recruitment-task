using Microsoft.Extensions.Options;
using MovieLibraryServer.Infrastructure.Options;
using RestSharp;

namespace MovieLibraryServer.Infrastructure.Clients;

public class ExternalMovieApiClient(IOptions<ExternalApiUrls> externalApiUrls) : BaseClient
{
    protected override RestClient Client { get; } = new(externalApiUrls.Value.ExternalMovieLibrary!);
}