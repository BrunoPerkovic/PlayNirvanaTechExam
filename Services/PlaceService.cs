using PlayNirvanaTechExam.Dtos;
using PlayNirvanaTechExam.Entities;
using PlayNirvanaTechExam.Interfaces.Repositories;
using PlayNirvanaTechExam.Interfaces.Services;

namespace PlayNirvanaTechExam.Services;

public class PlaceService : IPlaceService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IAuthService _authService;
    
    public PlaceService(IRepositoryManager repositoryManager, IAuthService authService)
    {
        _repositoryManager = repositoryManager;
        _authService = authService;
    }

    public async Task<Place> GetPlaceAsync(BaseRequest placeName)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseEntity> CreatePlaceAsync(BaseRequest place)
    {
        throw new NotImplementedException();
    }
}