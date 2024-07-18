using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models.ResponseModels;

public class GenreResponseModel
{
    [Required, MaxLength(24)]
    public string Name { get; set; }
}