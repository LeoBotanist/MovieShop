using System.Diagnostics.CodeAnalysis;
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
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
            .Include(m => m.MovieCasts)
            .ThenInclude(mc => mc.Cast)
            .ToList();
        foreach (var movie in movies)
        {
            Console.WriteLine($"Movie: {movie.Title}");
            foreach (var movieCast in movie.MovieCasts)
            {
                Console.WriteLine($"    -Actor: {movieCast.Cast.Name}, Role: {movieCast.Character}");
            }
        }
    }
}