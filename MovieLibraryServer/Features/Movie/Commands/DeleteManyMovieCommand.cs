using MediatR;
using MovieLibraryServer.Domain.Dto;

namespace MovieLibraryServer.Features.Movie.Commands;

public sealed class DeleteManyMovieCommand(List<IdDto> list) : IRequest
{
    public List<IdDto> EmployeesIdDtoList { get; set; } = list;
}
