using PlayNirvanaTechExam.Dtos;
using PlayNirvanaTechExam.Dtos.Place;
using PlayNirvanaTechExam.Entities;

namespace PlayNirvanaTechExam.Interfaces.Services;

public interface IPlaceService
{
    Task<List<PlaceDto>> GetPlacesAsync(BaseRequest baseRequest);
    Task<List<Place>> CreatePlacesAsync(BaseRequest baseRequest, int baseLocationId);
}