using System.ComponentModel.DataAnnotations;

namespace MovieLibraryServer.Domain.Dto;

public class IdDto
{
    [Key]
    public long Id { get; set; }
}