using Microsoft.EntityFrameworkCore;

namespace PlayNirvanaTechExam.Interfaces.Repositories;

public interface IRepositoryManager
{
    IPlaceRepository Place { get; }
    ILocationRepository Location { get; }
    Task SaveAsync();
    DbContext RepositoryContext { get; }
}