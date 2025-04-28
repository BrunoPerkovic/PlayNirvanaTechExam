namespace PlayNirvanaTechExam.Interfaces.Services;

public interface IServiceManager
{
    IPlaceService PlaceService { get; }
    ILocationService LocationService { get; }
    IAuthService AuthService { get; }
}