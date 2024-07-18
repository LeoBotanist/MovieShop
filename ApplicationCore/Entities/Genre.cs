using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Genre
{
    [Required]
    public int Id { get; set; }
    [Required, MaxLength(24)]
    public string Name { get; set; }

    public ICollection<Movie> Movies { get; set; }
}