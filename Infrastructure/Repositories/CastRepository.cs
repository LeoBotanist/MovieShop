using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CastRepository(MovieShopDbContext movieShopDbContext): BaseRepository<Cast>(movieShopDbContext), ICastRepository
{
    public new IEnumerable<Movie> GetById(int id)
    {
        // var result = movieShopDbContext.MovieCasts.
        return null;
    }
}