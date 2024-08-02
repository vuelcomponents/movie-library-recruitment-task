using Microsoft.EntityFrameworkCore;
using MovieLibraryServer.Domain.Entities;

namespace MovieLibraryServer.Infrastructure.Persistence.Data;

public class BaseMovieLibraryDataContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
     
    }
}