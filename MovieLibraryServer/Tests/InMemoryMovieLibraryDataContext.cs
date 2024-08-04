using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieLibraryServer.Infrastructure.Options;
using MovieLibraryServer.Infrastructure.Persistence.Data;

namespace MovieLibraryServer.Tests;

internal class InMemoryMovieLibraryDataContext(IOptions<ConnectionStrings> connectionStrings) : MovieLibraryDataContext(connectionStrings)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
        }
    }
}