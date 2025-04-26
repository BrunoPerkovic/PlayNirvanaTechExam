using Microsoft.EntityFrameworkCore;
using PlayNirvanaTechExam.Interfaces.Repositories;

namespace PlayNirvanaTechExam.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IPlaceRepository> _placeRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        _placeRepository = new Lazy<IPlaceRepository>(() => new PlaceRepository(repositoryContext));
    }

    public IPlaceRepository Place => _placeRepository.Value;
    public async Task SaveAsync()
    {
        await _repositoryContext.SaveChangesAsync();
    }

    public DbContext RepositoryContext { get; }
    
}