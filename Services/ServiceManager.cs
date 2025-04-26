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


    public ServiceManager(IRepositoryManager repositoryManager,
        UserManager<User> userManager,
        IConfiguration appSettings,
        IServiceScopeFactory serviceScopeFactory,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _authService = new Lazy<IAuthService>(() =>
            new AuthService(userManager, appSettings, httpContextAccessor));
        _placeService = new Lazy<IPlaceService>(() =>
        {
            var authService = _authService;
            return new PlaceService(repositoryManager, authService.Value);
        });
    }

    public IAuthService AuthService => _authService.Value;
    public IPlaceService PlaceService => _placeService.Value;
}