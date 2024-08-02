namespace MovieLibraryServer.Infrastructure.Extensions.AppExtensions;

public static class AppSpaProxyExtension
{
    private static readonly string ClientDevPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "MovieLibraryClient");
    private static readonly string ClientProdPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "MovieLibraryClient", "dist");
    public static IServiceCollection ConfigureSpaProxy(this IServiceCollection services)
    {
        // services.AddSpaStaticFiles(configuration =>
        // {
        //     configuration.RootPath = ClientProdPath;
        // });
        return services;
    }
    public static IApplicationBuilder UseSpaProxy(this WebApplication app)
    {
            // app.UseSpa(spa =>
            // {
            //     if (app.Environment.IsDevelopment())
            //     {
            //         spa.Options.SourcePath = ClientDevPath;
            //         spa.UseProxyToSpaDevelopmentServer("http://localhost:5173");
            //     }
            // });
            //
        return app;
    }
}