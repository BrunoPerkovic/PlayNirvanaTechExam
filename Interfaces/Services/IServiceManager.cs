namespace PlayNirvanaTechExam.Interfaces.Services;

public interface IServiceManager
{
    IPlaceService PlaceService { get; }
    IAuthService AuthService { get; }
}