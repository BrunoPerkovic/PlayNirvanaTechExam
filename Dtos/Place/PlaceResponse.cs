using PlayNirvanaTechExam.Dtos.Location;
using PlayNirvanaTechExam.Entities;

namespace PlayNirvanaTechExam.Dtos.Place;

public class PlaceResponse
{
    public int PlaceId { get; set; }
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? DisplayName { get; set; }
    public string? PrimaryType { get; set; }
    public string? PrimaryTypeDisplayName { get; set; }
    public string? NationalPhoneNumber { get; set; }
    public string? InternationalPhoneNumber { get; set; }
    public string? FormattedAddress { get; set; }
    public string? ShortFormattedAddress { get; set; }
    public int? Revision { get; set; }
    public string? RegionCode { get; set; }
    public string? LanguageCode { get; set; }
    public string? PostalCode { get; set; }
    public string? SortingCode { get; set; }
    public string? AdministrativeArea { get; set; }
    public string? Locality { get; set; }
    public string? Sublocality { get; set; }
    public string? GlobalCode { get; set; }
    public string? CompoundCode { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public double? Rating { get; set; }
    public string? GoogleMapsUri { get; set; }
    public string? WebsiteUri { get; set; }
    public string? AdrFormatAddress { get; set; }
    public BusinessStatus? BusinessStatus { get; set; }
    public PriceLevel? PriceLevel { get; set; }
    public string? IconMaskBaseUri { get; set; }
    public string? IconBackgroundColor { get; set; }
    public int? UtcOffsetMinutes { get; set; }
    public int? UserRatingCount { get; set; }
    public bool? Takeout { get; set; }
    public bool? Delivery { get; set; }
    public bool? DineIn { get; set; }
    public bool? CurbsidePickup { get; set; }
    public bool? Reservable { get; set; }
    public bool? ServesBreakfast { get; set; }
    public bool? ServesLunch { get; set; }
    public bool? ServesDinner { get; set; }
    public bool? ServesBeer { get; set; }
    public bool? ServesWine { get; set; }
    public bool? ServesBrunch { get; set; }
    public bool? ServesVegetarianFood { get; set; }
    public bool? OutdoorSeating { get; set; }
    public bool? LiveMusic { get; set; }
    public bool? MenuForChildren { get; set; }
    public bool? ServesCocktails { get; set; }
    public bool? ServesDessert { get; set; }
    public bool? ServesCoffee { get; set; }
    public bool? GoodForChildren { get; set; }
    public bool? AllowsDogs { get; set; }
    public bool? Restroom { get; set; }
    public bool? GoodForGroups { get; set; }
    public bool? GoodForWatchingSports { get; set; }
    public bool? PureServiceAreaBusiness { get; set; }
    public int LocationId { get; set; }
    public virtual BaseLocationDto BaseLocation { get; set; }
}