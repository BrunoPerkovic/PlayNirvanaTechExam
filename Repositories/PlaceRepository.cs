using PlayNirvanaTechExam.Entities;
using PlayNirvanaTechExam.Interfaces.Repositories;

namespace PlayNirvanaTechExam.Repositories;

public class PlaceRepository : RepositoryBase<Place>, IPlaceRepository
{
    public PlaceRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }
}