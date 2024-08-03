using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieLibraryServer.Infrastructure.Options;

namespace MovieLibraryServer.Infrastructure.Persistence.Data;

public class InMemoryMovieLibraryDataContext(IOptions<ConnectionStrings> connectionStrings) : MovieLibraryDataContext(connectionStrings)
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