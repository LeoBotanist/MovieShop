using ApplicationCore.Entities;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;

namespace ApplicationCore.Contract.Services;

public interface IMovieService
{
    int AddMovie(MovieRequestModel model);
    int UpdateMovie(MovieRequestModel model, int id);
    int DeleteMovie(int id);
    MovieResponseModel GetMovieById(int id);
    IEnumerable<MovieResponseModel> GetAllMovies();

    void PrintCasts();
}