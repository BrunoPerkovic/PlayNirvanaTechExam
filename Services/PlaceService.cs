using System.Text;
using Newtonsoft.Json;
using PlayNirvanaTechExam.Dtos;
using PlayNirvanaTechExam.Dtos.Place;
using PlayNirvanaTechExam.Entities;
using PlayNirvanaTechExam.Extensions;
using PlayNirvanaTechExam.Interfaces.Repositories;
using PlayNirvanaTechExam.Interfaces.Services;
using PlayNirvanaTechExam.RequestFeatures;

namespace PlayNirvanaTechExam.Services;

public class PlaceService : IPlaceService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _appSettings;

    public PlaceService(IRepositoryManager repositoryManager, HttpClient httpClient, IConfiguration appSettings)
    {
        _repositoryManager = repositoryManager;
        _httpClient = httpClient;
        _appSettings = appSettings;
    }

    public async Task<List<PlaceDto>> GetPlacesFromGoogleAsync(BaseRequest baseRequest)
    {
        var apiUrl = "https://places.googleapis.com/v1/places:searchNearby";

        // Serialize the request body
        var requestBody = JsonConvert.SerializeObject(baseRequest);
        HttpContent content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        // Clear and set headers
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("X-Goog-Api-Key", _appSettings.GetValue<string>("Google:X-Goog-Api-Key"));
        _httpClient.DefaultRequestHeaders.Add("X-Goog-FieldMask", _appSettings.GetValue<string>("Google:X-Goog-FieldMask"));

        try
        {
            // Make the API call
            var response = await _httpClient.PostAsync(apiUrl, content);

            // Log the response content for debugging
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(
                    $"Error fetching data from API: {response.StatusCode}, Response: {responseContent}");
            }

            // Deserialize the response
            var result = JsonConvert.DeserializeObject<PlacesResponse>(responseContent);

            return result?.Places ?? new List<PlaceDto>();
        }
        catch (Exception ex)
        {
            // Log the exception for debugging
            Console.WriteLine($"Exception: {ex.Message}");
            throw;
        }
    }

    public async Task<List<PlaceResponse>> GetAllPlaces(RequestParameters requestParameters, IQueryCollection queryParams)
    {
        var places = await _repositoryManager.Place.GetAllPlaces(requestParameters,queryParams);

        var placesResponse = new List<PlaceResponse>();
        foreach (var place in places)
        {
            var placeResponse = place.ToResponse();
            
            placesResponse.Add(placeResponse);
        }

        return placesResponse;
    }

    public async Task<List<PlaceResponse>> GetAllPlacesByLocation(RequestParameters requestParameters,
        int baseLocationId, IQueryCollection queryParams)
    {
        var places = await _repositoryManager.Place.GetAllPlacesByLocation(baseLocationId, requestParameters, queryParams);

        var placesResponse = new List<PlaceResponse>();
        foreach (var place in places)
        {
            var placeResponse = place.ToResponse();
            
            placesResponse.Add(placeResponse);
        }

        return placesResponse;
    }

    public async Task<List<Place>> CreatePlacesAsync(BaseRequest baseRequest, int baseLocationId)
    {
        // Implement the logic to create a place
        var googleResponse = await GetPlacesFromGoogleAsync(baseRequest);

        List<Place> places = new List<Place>();
        foreach (var res in googleResponse)
        {
            var place = new Place()
            {
                Id = res.Id ?? string.Empty,
                Name = res.Name ?? string.Empty,
                DisplayName = res.DisplayName?.Text ?? string.Empty,
                PrimaryType = res.PrimaryType ?? string.Empty,
                PrimaryTypeDisplayName = res.PrimaryTypeDisplayName?.Text ?? string.Empty,
                NationalPhoneNumber = res.NationalPhoneNumber ?? string.Empty,
                InternationalPhoneNumber = res.InternationalPhoneNumber ?? string.Empty,
                FormattedAddress = res.FormattedAddress ?? string.Empty,
                ShortFormattedAddress = res.ShortFormattedAddress ?? string.Empty,
                Revision = res.PostalAddress?.Revision ?? 0,
                RegionCode = res.PostalAddress?.RegionCode ?? string.Empty,
                LanguageCode = res.PostalAddress?.LanguageCode ?? string.Empty,
                PostalCode = res.PostalAddress?.PostalCode ?? string.Empty,
                SortingCode = res.PostalAddress?.SortingCode ?? string.Empty,
                AdministrativeArea = res.PostalAddress?.AdministrativeArea ?? string.Empty,
                Locality = res.PostalAddress?.Locality ?? string.Empty,
                Sublocality = res.PostalAddress?.Sublocality ?? string.Empty,
                GlobalCode = res.PlusCode?.GlobalCode ?? string.Empty,
                CompoundCode = res.PlusCode?.CompoundCode ?? string.Empty,
                Latitude = res.Location?.Latitude ?? 0.0,
                Longitude = res.Location?.Longitude ?? 0.0,
                Rating = res.Rating ?? 0.0,
                GoogleMapsUri = res.GoogleMapsUri ?? string.Empty,
                WebsiteUri = res.WebsiteUri ?? string.Empty,
                AdrFormatAddress = res.AdrFormatAddress ?? string.Empty,
                BusinessStatus = res.BusinessStatus ?? default,
                PriceLevel = res.PriceLevel ?? default,
                IconMaskBaseUri = res.IconMaskBaseUri ?? string.Empty,
                IconBackgroundColor = res.IconBackgroundColor ?? string.Empty,
                UtcOffsetMinutes = res.UtcOffsetMinutes ?? 0,
                UserRatingCount = res.UserRatingCount ?? 0,
                Takeout = res.Takeout ?? false,
                Delivery = res.Delivery ?? false,
                DineIn = res.DineIn ?? false,
                CurbsidePickup = res.CurbsidePickup ?? false,
                Reservable = res.Reservable ?? false,
                ServesBreakfast = res.ServesBreakfast ?? false,
                ServesLunch = res.ServesLunch ?? false,
                ServesDinner = res.ServesDinner ?? false,
                ServesBeer = res.ServesBeer ?? false,
                ServesWine = res.ServesWine ?? false,
                ServesBrunch = res.ServesBrunch ?? false,
                ServesVegetarianFood = res.ServesVegetarianFood ?? false,
                OutdoorSeating = res.OutdoorSeating ?? false,
                LiveMusic = res.LiveMusic ?? false,
                MenuForChildren = res.MenuForChildren ?? false,
                ServesCocktails = res.ServesCocktails ?? false,
                ServesDessert = res.ServesDessert ?? false,
                ServesCoffee = res.ServesCoffee ?? false,
                GoodForChildren = res.GoodForChildren ?? false,
                AllowsDogs = res.AllowsDogs ?? false,
                Restroom = res.Restroom ?? false,
                GoodForGroups = res.GoodForGroups ?? false,
                GoodForWatchingSports = res.GoodForWatchingSports ?? false,
                PureServiceAreaBusiness = res.PureServiceAreaBusiness ?? false,
                LocationId = baseLocationId
            };

            places.Add(place);
        }

        _repositoryManager.Place.CreatePlacesBulk(places);

        await _repositoryManager.SaveAsync();

        return places;
    }
}