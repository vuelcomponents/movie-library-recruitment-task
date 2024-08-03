using Microsoft.Extensions.Options;
using Moq;
using MovieLibraryServer.Domain.Dto;
using MovieLibraryServer.Domain.Entities;
using MovieLibraryServer.Features.Movie.Commands;
using MovieLibraryServer.Infrastructure.Options;
using MovieLibraryServer.Infrastructure.Persistence.Data;
using MovieLibraryServer.Infrastructure.Persistence.Repositories;
using Xunit;

namespace MovieLibraryServer.Tests.Integration;

public class CreateMovieCommandHandlerIntegrationTest
{
    [Fact]
    public async Task Handle_CreatesMovieAndReturnsMovieDto()
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
            
        var movieDto = new MovieDto
        {
            Id = 1,
            Title = "Updated Title",
            Director = "Updated Director",
            Rate = 5,
            Year = 2024
        };
    
        var command = new CreateMovieCommand(movieDto);
        var handler = new CreateMovieCommandHandler(movieRepository);
            
        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert

        Assert.Equal(movieDto.Title, result.Title);
        Assert.Equal(movieDto.Director, result.Director);
        Assert.Equal(movieDto.Rate, result.Rate);
        Assert.Equal(movieDto.Year, result.Year);
    }
}