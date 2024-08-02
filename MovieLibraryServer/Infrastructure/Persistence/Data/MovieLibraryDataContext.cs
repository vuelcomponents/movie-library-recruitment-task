using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieLibraryServer.Infrastructure.Options;

namespace MovieLibraryServer.Infrastructure.Persistence.Data;

public class MovieLibraryDataContext(IOptions<ConnectionStrings> connectionStrings) : BaseMovieLibraryDataContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(connectionStrings.Value.SqlServer!);
        }
    }
}