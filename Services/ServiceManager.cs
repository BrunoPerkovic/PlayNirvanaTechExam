using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using PlayNirvanaTechExam.Entities;
using PlayNirvanaTechExam.Hub;
using PlayNirvanaTechExam.Interfaces.Repositories;
using PlayNirvanaTechExam.Interfaces.Services;

namespace PlayNirvanaTechExam.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAuthService> _authService;
    private readonly Lazy<IPlaceService> _placeService;
    private readonly Lazy<ILocationService> _locationService;
    private readonly Lazy<INotificationService> _notificationService;
    private readonly Lazy<IRequestQueueService> _requestQueueService;

    public ServiceManager(IRepositoryManager repositoryManager,
        UserManager<User> userManager,
        IConfiguration appSettings,
        IHttpContextAccessor httpContextAccessor,
        HttpClient httpClient,
        IHubContext<SearchHub> searchHubContext)
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
        _notificationService = new Lazy<INotificationService>(() =>
        {
            return new NotificationService(searchHubContext);
        });

        _requestQueueService = new Lazy<IRequestQueueService>(() => { return new RequestQueueService(); });
    }

    public IAuthService AuthService => _authService.Value;
    public IPlaceService PlaceService => _placeService.Value;
    public ILocationService LocationService => _locationService.Value;
    public INotificationService NotificationService => _notificationService.Value;
    public IRequestQueueService RequestQueueService => _requestQueueService.Value;
}