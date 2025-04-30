using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayNirvanaTechExam.Dtos;
using PlayNirvanaTechExam.Interfaces.Services;
using PlayNirvanaTechExam.RequestFeatures;

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

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllPlaces([FromQuery] RequestParameters requestParameters)
    {
        var result = await _serviceManager.PlaceService.GetAllPlaces(requestParameters, Request.Query);

        return Ok(result);
    }

    [HttpGet("location/{baseLocationId:int}")]
    [Authorize]
    public async Task<IActionResult> GetPlacesByLocation([FromQuery] RequestParameters requestParameters,
        int baseLocationId)
    {
        var result = await _serviceManager.PlaceService.GetAllPlacesByLocation(requestParameters, baseLocationId, Request.Query);

        return Ok(result);
    }

    [HttpGet("all")]
    [Authorize]
    public async Task<IActionResult> GetAllPlacesAsync([FromQuery] RequestParameters requestParameters)
    {
        var result = await _serviceManager.PlaceService.GetAllPlacesAsync(requestParameters);

        return Ok(result);
    }

    [HttpGet("location/{baseLocationId:int}/all")]
    [Authorize]
    public async Task<IActionResult> GetAllPlacesByLocationAsync([FromQuery] RequestParameters requestParameters,
        int baseLocationId)
    {
        var result = await _serviceManager.PlaceService.GetPlacesByLocationAsync(requestParameters, baseLocationId);

        return Ok(result);
    }
}