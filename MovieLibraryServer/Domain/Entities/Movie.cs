namespace MovieLibraryServer.Domain.Entities;

public class Movie
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public string? Director { get; set; }
    public int Year { get; set; }
    public float? Rate { get; set; }
}