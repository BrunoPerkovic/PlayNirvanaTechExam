using PlayNirvanaTechExam.Dtos;
using PlayNirvanaTechExam.Entities;

namespace PlayNirvanaTechExam.Interfaces.Services;

public interface IPlaceService
{
    Task<Place> GetPlaceAsync(BaseRequest placeName);
    Task<BaseEntity> CreatePlaceAsync(BaseRequest place);
}