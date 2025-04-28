using Microsoft.AspNetCore.Mvc;
using PlayNirvanaTechExam.Dtos;
using PlayNirvanaTechExam.Interfaces.Services;

namespace PlayNirvanaTechExam.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly IServiceManager _service;

    public LocationController(IServiceManager service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("CreateLocationAndPlacesFromGoogle")]
    public async Task<IActionResult> CreateLocation([FromBody] BaseRequest baseRequest)
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
        
        var result = await _service.LocationService.CreateLocationAsync(baseRequest);
        return Ok(result);
    }
}