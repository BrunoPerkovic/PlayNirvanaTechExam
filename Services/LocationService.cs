using PlayNirvanaTechExam.Dtos;
using PlayNirvanaTechExam.Dtos.Location;
using PlayNirvanaTechExam.Entities;
using PlayNirvanaTechExam.Interfaces.Repositories;
using PlayNirvanaTechExam.Interfaces.Services;

namespace PlayNirvanaTechExam.Services;

public class LocationService : ILocationService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IPlaceService _placeService;
    public LocationService(IRepositoryManager repositoryManager, IPlaceService placeService)
    {
        _repositoryManager = repositoryManager;
        _placeService = placeService;
    }

    public async Task<BaseLocationDto> CreateLocationAsync(BaseRequest baseRequest)
    {
        var location = new BaseLocation
        {
            Longitude = baseRequest.LocationRestriction.Circle.Center.Longitude,
            Latitude = baseRequest.LocationRestriction.Circle.Center.Latitude,
            Radius = baseRequest.LocationRestriction.Circle.Radius
        };

        _repositoryManager.Location.CreateLocation(location);
        await _repositoryManager.SaveAsync();

        await _placeService.CreatePlacesAsync(baseRequest, location.Id);
        
        var locationDto = new BaseLocationDto
        {
            Longitude = location.Longitude,
            Latitude = location.Latitude,
            Radius = location.Radius,
        };
        
        return locationDto;
    }
}