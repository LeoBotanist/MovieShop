using ApplicationCore.Entities;

namespace MVC.Models;

public class MovieDetailPageModel
{
    public string? BackdropUrl { get; set; }
    public decimal? Budget { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ImdbUrl { get; set; }
    public string? OriginalLanguage { get; set; }
    public string? Overview { get; set; }
    public string? PosterUrl { get; set; }
    public decimal? Price { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public decimal? Revenue { get; set; }
    public int? RunTime { get; set; }
    public string? Tagline { get; set; }
    public string? Title { get; set; }
    public string? TmdbUrl { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public IEnumerable<Genre> Genres { get; set; } = [];
    public IEnumerable<MovieCast> MovieCasts { get; set; } = [];
    public IEnumerable<Purchase> Purchases { get; set; } = [];
    public IEnumerable<Review> Reviews { get; set; } = [];
    public IEnumerable<Trailer> Trailers { get; set; } = [];

    public double Rating { get; set; }
}