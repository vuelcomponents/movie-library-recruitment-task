
namespace MovieLibraryServer.Infrastructure.Extensions.StartupExtensions;

public static class StartupOptionsExtension
{
    public static IServiceCollection AddOptions(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        return services;
    }
}
