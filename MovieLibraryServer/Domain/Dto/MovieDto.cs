namespace MovieLibraryServer.Domain.Dto;

public class MovieDto
{
    public long? Id { get; set; }
    public string? Title { get; set; }
    public string? Director { get; set; }
    public int? Year { get; set; }
    public float? Rate { get; set; }
}