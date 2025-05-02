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
    /*
    private readonly INotificationService _notificationService;
    */

    public PlaceController(IServiceManager serviceManager, INotificationService notificationService)
    {
        _serviceManager = serviceManager;
        /*
        _notificationService = notificationService;
    */
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllPlaces([FromQuery] RequestParameters requestParameters)
    {
        var result = await _serviceManager.PlaceService.GetAllPlaces(requestParameters, Request.Query);
        await _serviceManager.NotificationService.NotifySearchPerformed(
            nameof(PlaceController).Replace("Controller", ""),
            nameof(GetAllPlaces),
            Request.QueryString.ToString(),
            Request.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown",
            result
        );
        return Ok(result);
    }

    [HttpGet("location/{baseLocationId:int}")]
    [Authorize]
    public async Task<IActionResult> GetPlacesByLocation([FromQuery] RequestParameters requestParameters,
        int baseLocationId)
    {
        var result = await _serviceManager.PlaceService.GetAllPlacesByLocation(requestParameters, baseLocationId, Request.Query);
        await _serviceManager.NotificationService.NotifySearchPerformed(
            nameof(PlaceController).Replace("Controller", ""),
            nameof(GetPlacesByLocation),
            Request.QueryString.ToString(),
            Request.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown",
            result
        );
        return Ok(result);
    }

    [HttpGet("all")]
    [Authorize]
    public async Task<IActionResult> GetAllPlacesAsync([FromQuery] RequestParameters requestParameters)
    {
        var result = await _serviceManager.PlaceService.GetAllPlacesAsync(requestParameters);
        await _serviceManager.NotificationService.NotifySearchPerformed(
            nameof(PlaceController).Replace("Controller", ""),
            nameof(GetAllPlacesAsync),
            Request.QueryString.ToString(),
            Request.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown",
            result
        );
        return Ok(result);
    }

    [HttpGet("location/{baseLocationId:int}/all")]
    [Authorize]
    public async Task<IActionResult> GetAllPlacesByLocationAsync([FromQuery] RequestParameters requestParameters,
        int baseLocationId)
    {
        var result = await _serviceManager.PlaceService.GetPlacesByLocationAsync(requestParameters, baseLocationId);
        await _serviceManager.NotificationService.NotifySearchPerformed(
            nameof(PlaceController).Replace("Controller", ""),
            nameof(GetAllPlacesByLocationAsync),
            Request.QueryString.ToString(),
            Request.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown",
            result
        );
        return Ok(result);
    }
}