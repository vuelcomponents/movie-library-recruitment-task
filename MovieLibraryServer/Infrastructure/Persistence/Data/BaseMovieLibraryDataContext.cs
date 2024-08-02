using Microsoft.EntityFrameworkCore;
using MovieLibraryServer.Domain.Entities;
using MovieLibraryServer.Infrastructure.Persistence.Data.EntityTypeConfiguration;

namespace MovieLibraryServer.Infrastructure.Persistence.Data;

public class BaseMovieLibraryDataContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new MovieEntityTypeConfiguration().Configure(modelBuilder.Entity<Movie>());
    }
}