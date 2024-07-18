using System.Diagnostics.CodeAnalysis;
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models.ResponseModels;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MovieRepository(MovieShopDbContext movieShopDbContext) : BaseRepository<Movie>(movieShopDbContext), IMovieRepository
{
    
    public Movie? GetHighestGrossingMovie()
    {
       return _movieShopDbContext.Set<Movie>().ToList().MinBy(m => m.Revenue);
    }
    
    
    public void PrintCasts()
    {
        var movies = _movieShopDbContext.Movies
            .Include(m => m.MovieGenres)
            .ThenInclude(mv => mv.Genre)
            .ToList();
        foreach (var movie in movies)
        {
            Console.WriteLine($"Movie: {movie.Title}");
            foreach (var movieGenre in movie.MovieGenres)
            {
                Console.WriteLine($"    -Genre: {movieGenre.Genre.Name}");
            }
        }
    }

    public MovieDetailResponseModel GetMovieDetailsById(int id)
    {
        var model = _movieShopDbContext.Set<Movie>()
            .Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Genre)
            .Include(m => m.MovieCasts)
            .ThenInclude(mc => mc.Cast)
            .Include(m => m.Reviews)
            .Include(m => m.Purchases)
            .FirstOrDefault(m => m.Id == id);

        MovieDetailResponseModel entity = new MovieDetailResponseModel();
        entity.BackdropUrl = model.BackdropUrl;
        entity.Budget = model.Budget;
        entity.Tagline = model.Tagline;
        entity.Price = model.Price;
        entity.Revenue = model.Revenue;
        entity.Title = model.Title;
        entity.CreatedBy = model.CreatedBy;
        entity.CreatedDate = model.CreatedDate;
        entity.ImdbUrl = model.ImdbUrl;
        entity.Overview = model.Overview;
        entity.OriginalLanguage = model.OriginalLanguage;
        entity.PosterUrl = model.PosterUrl;
        entity.ReleaseDate = model.ReleaseDate;
        entity.RunTime = model.RunTime;
        entity.TmdbUrl = model.TmdbUrl;
        entity.UpdatedDate = model.UpdatedDate;
        entity.UpdatedBy = model.UpdatedBy;
        entity.Casts = model.MovieCasts.Select(mc=>mc.Cast).ToList();
        entity.Genres = model.MovieGenres.Select(mg => mg.Genre).ToList();
        entity.Reviews = model.Reviews.ToList();
        entity.Purchases = model.Purchases.ToList();
        return entity;
    }
}