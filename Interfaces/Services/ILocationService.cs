using PlayNirvanaTechExam.Dtos;
using PlayNirvanaTechExam.Dtos.Location;

namespace PlayNirvanaTechExam.Interfaces.Services;

public interface ILocationService
{
    Task<BaseLocationDto> CreateLocationAsync(BaseRequest baseRequest);
}