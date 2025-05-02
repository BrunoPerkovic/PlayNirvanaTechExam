using Microsoft.EntityFrameworkCore;
using PlayNirvanaTechExam.Entities;
using PlayNirvanaTechExam.Interfaces.Repositories;
using PlayNirvanaTechExam.Repositories.Extensions;
using PlayNirvanaTechExam.RequestFeatures;

namespace PlayNirvanaTechExam.Repositories;

public class PlaceRepository : RepositoryBase<Place>, IPlaceRepository
{
    public PlaceRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<List<Place>> GetAllPlaces(RequestParameters requestParameters, IQueryCollection queryParams)
    {
        var places = await FindAll(false)
            .FilterByProperties(queryParams)
            .Search(requestParameters.SearchTerm)
            .Include(p => p.BaseLocation)
            .ToListAsync();

        return places;
    }

    public async Task<List<Place>> GetAllPlacesByLocation(int locationId, RequestParameters requestParameters, IQueryCollection queryParams)
    {
        var places = await FindByCondition(p => p.LocationId == locationId, false)
            .FilterByProperties(queryParams)
            .Search(requestParameters.SearchTerm)
            .Include(p => p.BaseLocation)
            .ToListAsync();

        return places;
    }

    public void CreatePlacesBulk(IEnumerable<Place> places)
    {
        BulkCreate(places);
    }
}