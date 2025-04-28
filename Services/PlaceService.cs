using System.Text;
using Newtonsoft.Json;
using PlayNirvanaTechExam.Dtos;
using PlayNirvanaTechExam.Dtos.Place;
using PlayNirvanaTechExam.Entities;
using PlayNirvanaTechExam.Interfaces.Repositories;
using PlayNirvanaTechExam.Interfaces.Services;

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

    public async Task<List<PlaceDto>> GetPlacesAsync(BaseRequest baseRequest)
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
                throw new Exception($"Error fetching data from API: {response.StatusCode}, Response: {responseContent}");
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

    public async Task<List<Place>> CreatePlacesAsync(BaseRequest baseRequest, int baseLocationId)
    {
        // Implement the logic to create a place
        var googleResponse = await GetPlacesAsync(baseRequest);

        List<Place> places = new List<Place>();
        foreach (var res in googleResponse)
        {
            var place = new Place()
            {
                Id = res.Id,
                Name = res.Name,
                DisplayName = res.DisplayName.Text,
                PrimaryType = res.PrimaryType,
                PrimaryTypeDisplayName = res.PrimaryTypeDisplayName.Text,
                NationalPhoneNumber = res.NationalPhoneNumber,
                InternationalPhoneNumber = res.InternationalPhoneNumber,
                FormattedAddress = res.FormattedAddress,
                ShortFormattedAddress = res.ShortFormattedAddress,
                Revision = res.PostalAddress.Revision,
                RegionCode = res.PostalAddress.RegionCode,
                LanguageCode = res.PostalAddress.LanguageCode,
                PostalCode = res.PostalAddress.PostalCode,
                SortingCode = res.PostalAddress.SortingCode,
                AdministrativeArea = res.PostalAddress.AdministrativeArea,
                Locality = res.PostalAddress.Locality,
                Sublocality = res.PostalAddress.Sublocality,
                GlobalCode = res.PlusCode.GlobalCode,
                CompoundCode = res.PlusCode.CompoundCode,
                Latitude = res.Location.Latitude,
                Longitude = res.Location.Longitude,
                Rating = res.Rating,
                GoogleMapsUri = res.GoogleMapsUri,
                WebsiteUri = res.WebsiteUri,
                AdrFormatAddress = res.AdrFormatAddress,
                BusinessStatus = res.BusinessStatus,
                PriceLevel = res.PriceLevel,
                IconMaskBaseUri = res.IconMaskBaseUri,
                IconBackgroundColor = res.IconBackgroundColor,
                UtcOffsetMinutes = res.UtcOffsetMinutes,
                UserRatingCount = res.UserRatingCount,
                Takeout = res.Takeout,
                Delivery = res.Delivery,
                DineIn = res.DineIn,
                CurbsidePickup = res.CurbsidePickup,
                Reservable = res.Reservable,
                ServesBreakfast = res.ServesBreakfast,
                ServesLunch = res.ServesLunch,
                ServesDinner = res.ServesDinner,
                ServesBeer = res.ServesBeer,
                ServesWine = res.ServesWine,
                ServesBrunch = res.ServesBrunch,
                ServesVegetarianFood = res.ServesVegetarianFood,
                OutdoorSeating = res.OutdoorSeating,
                LiveMusic = res.LiveMusic,
                MenuForChildren = res.MenuForChildren,
                ServesCocktails = res.ServesCocktails,
                ServesDessert = res.ServesDessert,
                ServesCoffee = res.ServesCoffee,
                GoodForChildren = res.GoodForChildren,
                AllowsDogs = res.AllowsDogs,
                Restroom = res.Restroom,
                GoodForGroups = res.GoodForGroups,
                GoodForWatchingSports = res.GoodForWatchingSports,
                PureServiceAreaBusiness = res.PureServiceAreaBusiness,
                LocationId = baseLocationId
            };

            places.Add(place);
        }

        _repositoryManager.Place.CreatePlacesBulk(places);
        
        await _repositoryManager.SaveAsync();
        
        return places;
    }
}