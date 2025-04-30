using Microsoft.EntityFrameworkCore;
using PlayNirvanaTechExam.Entities;
using PlayNirvanaTechExam.Interfaces.Repositories;

namespace PlayNirvanaTechExam.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IPlaceRepository> _placeRepository;
    private readonly Lazy<ILocationRepository> _locationRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        _placeRepository = new Lazy<IPlaceRepository>(() => new PlaceRepository(repositoryContext));
        _locationRepository = new Lazy<ILocationRepository>(() => new LocationRepository(repositoryContext));
    }

    public IPlaceRepository Place => _placeRepository.Value;
    public ILocationRepository Location => _locationRepository.Value;
    public async Task SaveAsync()
    {
        await _repositoryContext.SaveChangesAsync();
    }

    public DbContext RepositoryContext { get; }

    
}