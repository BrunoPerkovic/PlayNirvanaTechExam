using PlayNirvanaTechExam.Dtos;
using PlayNirvanaTechExam.Dtos.Place;
using PlayNirvanaTechExam.Entities;
using PlayNirvanaTechExam.RequestFeatures;

namespace PlayNirvanaTechExam.Interfaces.Services;

public interface IPlaceService
{
    Task<List<PlaceResponse>> GetAllPlaces(RequestParameters requestParameters);
    Task<List<PlaceResponse>> GetAllPlacesByLocation(RequestParameters requestParameters, int baseLocationId);
    Task<PlaceDtoWithMetaData> GetAllPlacesAsync(RequestParameters requestParameters);
    Task<PlaceDtoWithMetaData> GetPlacesByLocationAsync(RequestParameters requestParameters, int baseLocationId);
    Task<List<Place>> CreatePlacesAsync(BaseRequest baseRequest, int baseLocationId);
}