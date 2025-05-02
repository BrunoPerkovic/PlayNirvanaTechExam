using PlayNirvanaTechExam.Dtos;
using PlayNirvanaTechExam.Dtos.Place;
using PlayNirvanaTechExam.Entities;
using PlayNirvanaTechExam.RequestFeatures;

namespace PlayNirvanaTechExam.Interfaces.Services;

public interface IPlaceService
{
    Task<List<PlaceResponse>> GetAllPlaces(RequestParameters requestParameters, IQueryCollection queryParams);
    Task<List<PlaceResponse>> GetAllPlacesByLocation(RequestParameters requestParameters, int baseLocationId, IQueryCollection queryParams);
    Task<List<Place>> CreatePlacesAsync(BaseRequest baseRequest, int baseLocationId);
}