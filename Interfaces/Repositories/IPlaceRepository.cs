using PlayNirvanaTechExam.Entities;
using PlayNirvanaTechExam.RequestFeatures;

namespace PlayNirvanaTechExam.Interfaces.Repositories;

public interface IPlaceRepository
{
    Task<List<Place>> GetAllPlaces(RequestParameters requestParameters, IQueryCollection queryParams);
    Task<List<Place>> GetAllPlacesByLocation(int locationId, RequestParameters requestParameters, IQueryCollection queryParams);
    void CreatePlacesBulk(IEnumerable<Place> places);
}