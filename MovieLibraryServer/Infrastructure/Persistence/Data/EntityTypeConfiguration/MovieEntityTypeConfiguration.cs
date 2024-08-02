using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieLibraryServer.Domain.Entities;

namespace MovieLibraryServer.Infrastructure.Persistence.Data.EntityTypeConfiguration;

public class MovieEntityTypeConfiguration : IEntityTypeConfiguration<Movie>
{
    [Obsolete("Obsolete")]
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.Property(e => e.Title).IsRequired().HasMaxLength(200);
        builder.HasCheckConstraint("CK_Movie_Year", "Year >= 1900 AND Year <= 2200");
    }
}