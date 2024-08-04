using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieLibraryServer.Domain.Entities;
using MovieLibraryServer.Infrastructure.Options;

namespace MovieLibraryServer.Infrastructure.Persistence.Data;

public class MovieLibraryDataContext(IOptions<ConnectionStrings> connectionStrings) : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(connectionStrings.Value.SqlServer!);
        }
    }
}