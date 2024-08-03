using Microsoft.Extensions.Options;
using Moq;
using MovieLibraryServer.Domain.Entities;
using MovieLibraryServer.Features.Movie.Queries;
using MovieLibraryServer.Infrastructure.Options;
using MovieLibraryServer.Infrastructure.Persistence.Data;
using MovieLibraryServer.Infrastructure.Persistence.Repositories;
using Xunit;

namespace MovieLibraryServer.Tests.Integration;

public class GetMovieByIdQueryIntegrationTest
{
    [Fact]
    public async Task Handle_GetMovieById_MovieExists_GetByIdAndReturnsMovieDto()
    {
            
        // Arrange
        var mockOptions = new Mock<IOptions<ConnectionStrings>>();
        mockOptions.Setup(options => options.Value)
            .Returns(new ConnectionStrings
            {
                SqlServer = "YourConnectionStringHere"
            });
        var inMemoryMovieLibraryDataContext = new InMemoryMovieLibraryDataContext(mockOptions.Object);
        var movieRepository = new MovieRepository(inMemoryMovieLibraryDataContext);
            
        var movie = new Movie
        {
            Id = 1,
            Title = "Old Title",
            Director = "Old Director",
            Rate = 3,
            Year = 2023
        };
        inMemoryMovieLibraryDataContext.Movies.Add(movie);
        await inMemoryMovieLibraryDataContext.SaveChangesAsync();
    
        var command = new GetMovieByIdQuery(1);
        var handler = new GetMovieByIdQueryHandler(movieRepository);
            
        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(movie.Id, result.Id);
        Assert.Equal(movie.Title, result.Title);
        Assert.Equal(movie.Director, result.Director);
        Assert.Equal(movie.Rate, result.Rate);
        Assert.Equal(movie.Year, result.Year);
    }
}