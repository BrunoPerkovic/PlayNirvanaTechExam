using PlayNirvanaTechExam.Entities;
using PlayNirvanaTechExam.Interfaces.Repositories;

namespace PlayNirvanaTechExam.Repositories;

public class LocationRepository : RepositoryBase<BaseLocation>, ILocationRepository
{
    public LocationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateLocation(BaseLocation location)
    {
        Create(location);
    }
}
