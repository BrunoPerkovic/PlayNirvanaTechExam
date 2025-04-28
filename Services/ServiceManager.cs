using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PlayNirvanaTechExam.Entities;
using PlayNirvanaTechExam.Interfaces.Repositories;
using PlayNirvanaTechExam.Interfaces.Services;

namespace PlayNirvanaTechExam.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAuthService> _authService;
    private readonly Lazy<IPlaceService> _placeService;
    private readonly Lazy<ILocationService> _locationService;


    public ServiceManager(IRepositoryManager repositoryManager,
        UserManager<User> userManager,
        IConfiguration appSettings,
        IServiceScopeFactory serviceScopeFactory,
        IHttpContextAccessor httpContextAccessor,
        HttpClient httpClient
    )
    {
        _authService = new Lazy<IAuthService>(() =>
            new AuthService(userManager, appSettings, httpContextAccessor));
        _placeService = new Lazy<IPlaceService>(() =>
        {
            return new PlaceService(repositoryManager, httpClient, appSettings);
        });
        
        _locationService = new Lazy<ILocationService>(() =>
        {
            return new LocationService(repositoryManager, _placeService.Value);
        });
    
    }

    public IAuthService AuthService => _authService.Value;
    public IPlaceService PlaceService => _placeService.Value;
    public ILocationService LocationService => _locationService.Value;
}