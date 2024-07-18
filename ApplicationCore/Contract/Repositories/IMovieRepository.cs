using ApplicationCore.Entities;

namespace ApplicationCore.Contract.Repositories;

public interface IMovieRepository: IRepository<Movie>
{
    Movie? GetHighestGrossingMovie();

    void PrintCasts();
}