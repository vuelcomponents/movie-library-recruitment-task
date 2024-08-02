using FluentValidation;
using MediatR;
using MovieLibraryServer.Domain.Behaviours;

namespace MovieLibraryServer.Infrastructure.Extensions.StartupExtensions;

public static class StartupMediatorExtension
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        services.AddValidatorsFromAssembly(typeof(Program).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        return services;
    }
}
