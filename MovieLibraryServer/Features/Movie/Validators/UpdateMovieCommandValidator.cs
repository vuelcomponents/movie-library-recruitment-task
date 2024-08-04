using FluentValidation;
using MovieLibraryServer.Features.Movie.Commands;

namespace MovieLibraryServer.Features.Movie.Validators;

public sealed class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
{
    public UpdateMovieCommandValidator()
    {
        RuleFor(x => x.MovieDto.Id).NotNull().WithMessage("Id cannot be empty");
        RuleFor(x => x.MovieDto.Title)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Title cannot be empty and cannot contain less than 200 characters");
        RuleFor(x => x.MovieDto.Year)
            .NotNull()
            .GreaterThan(1900)
            .LessThan(2200)
            .WithMessage("Year must be between 1900 and 2200");
        RuleFor(x => x.MovieDto.Rate)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(10)
            .WithMessage("Rate must be between 0 and 10");
    }
}
