using Microsoft.AspNetCore.Mvc;
using PlayNirvanaTechExam.Dtos;
using PlayNirvanaTechExam.Interfaces.Services;

namespace PlayNirvanaTechExam.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlaceController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public PlaceController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    /*[HttpPost]
    public async Task<IActionResult> CreatePlace([FromBody] BaseRequest baseRequest)
    {
        if (baseRequest == null)
        {
            return BadRequest("Place cannot be null");
        }

        if (baseRequest.LocationRestriction.Circle.Center.Longitude is < -180 or > 180)
        {
            return BadRequest("Longitude must be between -180 and 180");
        }

        if (baseRequest.LocationRestriction.Circle.Center.Latitude is < -90 or > 90)
        {
            return BadRequest("Latitude must be between -90 and 90");
        }

        if (baseRequest.LocationRestriction.Circle.Radius is <= 0 or > 50000.0) 
        {
            return BadRequest("Radius must be between 0 and 50000");
        }

       // var createdPlace = await _serviceManager.PlaceService.CreatePlaceAsync(baseRequest);

        return Ok(baseRequest);
    }*/
    
    [HttpGet]
    public async Task<IActionResult> GetPlaces([FromQuery] BaseRequest baseRequest)
    {
        if (baseRequest == null)
        {
            return BadRequest("Base request cannot be null");
        }

        var places = await _serviceManager.PlaceService.GetPlacesAsync(baseRequest);

        return Ok(places);
    }
    
}