using Microsoft.Extensions.Options;
using Moq;
using MovieLibraryServer.Domain.Dto;
using MovieLibraryServer.Features.Movie.Queries;
using MovieLibraryServer.Infrastructure.Options;
using MovieLibraryServer.Infrastructure.Persistence.Repositories;
using Xunit;

namespace MovieLibraryServer.Tests.Integration;

public class GetAllMovieQueryIntegrationTest
{
    [Fact]
    public async Task Handle_GetAllMovies_ReturnsListMovieDto()
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
      
        var command = new GetAllMovieQuery();
        var handler = new GetAllMovieQueryHandler(movieRepository);
            
        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsType<List<MovieDto>>(result);
    }
}