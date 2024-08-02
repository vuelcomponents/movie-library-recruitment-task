using MovieLibraryServer.Infrastructure.Clients;

namespace MovieLibraryServer.Infrastructure.Extensions.StartupExtensions;

public static class StartupClientsExtension
{
    public static IServiceCollection AddClients(this IServiceCollection services)
    {
        services.AddTransient<ExternalMovieApiClient>();
        return services;
    }
}