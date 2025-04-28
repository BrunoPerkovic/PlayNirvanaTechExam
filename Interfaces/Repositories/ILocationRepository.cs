using PlayNirvanaTechExam.Entities;

namespace PlayNirvanaTechExam.Interfaces.Repositories;

public interface ILocationRepository
{
    void CreateLocation(BaseLocation location);
}