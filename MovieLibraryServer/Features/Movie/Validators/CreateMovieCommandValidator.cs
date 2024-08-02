using FluentValidation;
using MovieLibraryServer.Features.Movie.Commands;

namespace MovieLibraryServer.Features.Movie.Validators;

public sealed class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieCommandValidator()
    {
        RuleFor(x => x.MovieCreateDto.Title)
            .NotNull()
            .MaximumLength(200)
            .WithMessage("Title cannot be empty and cannot contain less than 200 characters");
        RuleFor(x => x.MovieCreateDto.Year)
            .NotNull()
            .GreaterThan(1900)
            .LessThan(2200)
            .WithMessage("Year must be between 1900 and 2200");
    }
}
