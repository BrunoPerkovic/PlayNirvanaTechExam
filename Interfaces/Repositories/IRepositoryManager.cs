using Microsoft.EntityFrameworkCore;

namespace PlayNirvanaTechExam.Interfaces.Repositories;

public interface IRepositoryManager
{
    IPlaceRepository Place { get; }
    Task SaveAsync();
    DbContext RepositoryContext { get; }
}