using FluentValidation;
using MovieLibraryServer.Features.Movie.Commands;

namespace MovieLibraryServer.Features.Movie.Validators;

public sealed class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieCommandValidator()
    {
        RuleFor(x => x.MovieCreateDto.Title)
            .NotNull()
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Title cannot be empty and cannot contain less than 200 characters");
        RuleFor(x => x.MovieCreateDto.Year)
            .NotNull()
            .GreaterThan(1900)
            .LessThan(2200)
            .WithMessage("Year must be between 1900 and 2200");
        RuleFor(x => x.MovieCreateDto.Rate)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(10)
            .WithMessage("Rate must be between 0 and 10");
    }
}
