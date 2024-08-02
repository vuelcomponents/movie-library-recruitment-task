
using MovieLibraryServer.Infrastructure.Options;

namespace MovieLibraryServer.Infrastructure.Extensions.StartupExtensions;

public static class StartupOptionsExtension
{
    public static IServiceCollection AddOptions(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
        services.Configure<ExternalApiUrls>(configuration.GetSection("ExternalApiUrls"));
        return services;
    }
}
