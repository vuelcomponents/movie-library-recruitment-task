using Microsoft.Extensions.Options;
using Moq;
using MovieLibraryServer.Domain.Dto;
using MovieLibraryServer.Features.Movie.Commands;
using MovieLibraryServer.Infrastructure.Clients;
using MovieLibraryServer.Infrastructure.Options;
using MovieLibraryServer.Infrastructure.Persistence.Data;
using MovieLibraryServer.Infrastructure.Persistence.Repositories;
using Xunit;

namespace MovieLibraryServer.Tests.Integration;

public class IntegrateMovieCommandHandlerIntegrationTest
{
    [Fact]
    public async Task Handle_IntegrateMovie_GetAllFromApi_SaveInDatabase_ReturnsListMovieDto()
    {
            
        // Arrange
        var mockRepositoryOptions = new Mock<IOptions<ConnectionStrings>>();
        mockRepositoryOptions.Setup(options => options.Value)
            .Returns(new ConnectionStrings
            {
                SqlServer = "YourConnectionStringHere"
            });
        var mockApiClientOptions = new Mock<IOptions<ExternalApiUrls>>();
        mockApiClientOptions.Setup(options => options.Value)
            .Returns(new ExternalApiUrls
            {
                ExternalMovieLibrary = "https://test.url"
            });
        
        var inMemoryMovieLibraryDataContext = new InMemoryMovieLibraryDataContext(mockRepositoryOptions.Object);
        var movieRepository = new MovieRepository(inMemoryMovieLibraryDataContext);
        
        var apiClient = new Mock<ExternalMovieApiClient>(mockApiClientOptions.Object);
        apiClient.Setup(options => options.GetAsync<List<MovieDto>>(It.IsAny<string>(), It.IsAny<Action<Exception>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync([
                new MovieDto
                {
                    Id = 1,
                    Title = "Updated Title",
                    Director = "Updated Director",
                    Rate = 5,
                    Year = 2024
                }
            ]);
        
        var command = new IntegrateMovieCommand();
        var handler = new IntegrateMovieCommandHandler(apiClient.Object, movieRepository);
            
        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsType<List<MovieDto>>(result);
    }
}