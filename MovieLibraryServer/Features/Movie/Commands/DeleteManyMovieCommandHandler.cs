using MediatR;
using MovieLibraryServer.Infrastructure.Persistence.Repositories;

namespace MovieLibraryServer.Features.Movie.Commands;

public sealed class DeleteManyMovieCommandHandler(
    IMovieRepository movieRepository
) : IRequestHandler<DeleteManyMovieCommand>
{
    public async Task Handle(DeleteManyMovieCommand request, CancellationToken cancellationToken)
    {
        await movieRepository
            .DeleteManyByIdDtoList(request.EmployeesIdDtoList, cancellationToken);
        await movieRepository.SaveAsync(cancellationToken);
    }
}
