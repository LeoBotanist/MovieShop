using ApplicationCore.Entities;
using ApplicationCore.Models.ResponseModels;

namespace ApplicationCore.Contract.Repositories;

public interface IMovieRepository: IRepository<Movie>
{
    Movie? GetHighestGrossingMovie();

    void PrintCasts();
    MovieDetailResponseModel GetMovieDetailsById(int id);
}