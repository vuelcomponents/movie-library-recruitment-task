using AsyncAwaitBestPractices;
using MediatR;
using MovieLibraryServer.Infrastructure.Persistence.Repositories;

namespace MovieLibraryServer.Features.Movie.Commands;

public sealed class DeleteManyMovieCommandHandler(
    IMovieRepository<Domain.Entities.Movie> movieRepository
) : IRequestHandler<DeleteManyMovieCommand>
{
    public Task Handle(DeleteManyMovieCommand request, CancellationToken cancellationToken)
    {
        movieRepository
            .DeleteManyByIdDtoList(request.EmployeesIdDtoList)
            .SafeFireAndForget(e =>
            {
                /*
                     Tutaj mozna wyslac np przez socket powiadomienie, ze usuwanie sie nie powiodlo
                 */
                Console.WriteLine(
                    $"Removal has not been accomplished successfully. {e.InnerException?.Message}"
                );
            });
        return Task.CompletedTask;
    }
}
