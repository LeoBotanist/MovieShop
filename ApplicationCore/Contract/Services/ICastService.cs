using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;

namespace ApplicationCore.Contract.Services;

public interface ICastService
{
    int AddCast(CastRequestModel model);
    int UpdateCast(UserRequestModel model, int id);
    int DeleteCast(int id);
    CastResponseModel GetCastById(int id);
    IEnumerable<CastResponseModel> GetAllCasts();
}