using MediatR;
using MovieLibraryServer.Domain.Dto;

namespace MovieLibraryServer.Features.Movie.Queries;

public sealed class GetAllMovieQuery : IRequest<List<MovieDto>>;
