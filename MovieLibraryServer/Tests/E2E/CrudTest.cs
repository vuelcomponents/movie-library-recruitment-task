using Microsoft.Extensions.Options;
using Moq;
using MovieLibraryServer.Domain.Dto;
using MovieLibraryServer.Features.Movie.Commands;
using MovieLibraryServer.Features.Movie.Queries;
using MovieLibraryServer.Infrastructure.Options;
using MovieLibraryServer.Infrastructure.Persistence.Data;
using MovieLibraryServer.Infrastructure.Persistence.Repositories;
using Xunit;

namespace MovieLibraryServer.Tests.E2E;

public class CrudTest
{
    [Fact]
    public async Task Can_Create_Read_Update_Delete_Book()
    {
        /*
             CREATE
         */
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
    
        var createCommand = new CreateMovieCommand(movieDto);
        var createHandler = new CreateMovieCommandHandler(movieRepository);
            
        // Act
        var createResult = await createHandler.Handle(createCommand, CancellationToken.None);

        // Assert

        Assert.Equal(movieDto.Title, createResult.Title);
        Assert.Equal(movieDto.Director, createResult.Director);
        Assert.Equal(movieDto.Rate, createResult.Rate);
        Assert.Equal(movieDto.Year, createResult.Year);
        
        /*
            READ
         */
        // Arrange
        var getCommand = new GetMovieByIdQuery(1);
        var getHandler = new GetMovieByIdQueryHandler(movieRepository);
            
        // Act
        var result = await getHandler.Handle(getCommand, CancellationToken.None);

        // Assert
        Assert.Equal(movieDto.Id, result.Id);
        Assert.Equal(movieDto.Title, result.Title);
        Assert.Equal(movieDto.Director, result.Director);
        Assert.Equal(movieDto.Rate, result.Rate);
        Assert.Equal(movieDto.Year, result.Year);
        
        /*
           UPDATE
        */
        //Arrange
        var updateMovieDto = new MovieDto
        {
            Id = 1,
            Title = "Updated Title",
            Director = "Updated Director",
            Rate = 5,
            Year = 2024
        };
        var updateCommand = new UpdateMovieCommand(movieDto);
        var updateHandler = new UpdateMovieCommandHandler(movieRepository);
        
        // Act
        var updateResult = await updateHandler.Handle(updateCommand, CancellationToken.None);

        // Assert
        Assert.Equal(updateMovieDto.Title, updateResult.Title);
        Assert.Equal(updateMovieDto.Director, updateResult.Director);
        Assert.Equal(updateMovieDto.Rate, updateResult.Rate);
        Assert.Equal(updateMovieDto.Year, updateResult.Year);
        /*
            Delete
        */
        // Arrange
        var deleteCommand = new DeleteManyMovieCommand([new IdDto{Id=1}]);
        var deleteCommandHandler = new DeleteManyMovieCommandHandler(movieRepository);
        //Act
        await deleteCommandHandler.Handle(deleteCommand, CancellationToken.None);
        var deleteResult = await movieRepository.GetAsync(m => m.Id.Equals(1));
        //Assert
        Assert.Null(deleteResult);
    }
}