using MediatR;
using MovieLibraryServer.Domain.Dto;

namespace MovieLibraryServer.Features.Movie.Commands;

public sealed class IntegrateMovieCommand : IRequest<List<MovieDto>>;
