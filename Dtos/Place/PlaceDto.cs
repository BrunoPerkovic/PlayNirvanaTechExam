using System.ComponentModel.DataAnnotations;
using PlayNirvanaTechExam.Entities;

namespace PlayNirvanaTechExam.Dtos.Place;

public class PlaceDto
{
    [Key] public int PlaceId { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
    public LocalizedText DisplayName { get; set; }
    public List<string> Types { get; set; }
    public string PrimaryType { get; set; }
    public LocalizedText PrimaryTypeDisplayName { get; set; }
    public string NationalPhoneNumber { get; set; }
    public string InternationalPhoneNumber { get; set; }
    public string FormattedAddress { get; set; }
    public string ShortFormattedAddress { get; set; }
    public PostalAddress PostalAddress { get; set; }
    public List<AddressComponent> AddressComponents { get; set; }
    public PlusCode PlusCode { get; set; }
    public LatLng Location { get; set; }
    public Viewport Viewport { get; set; }
    public double? Rating { get; set; }
    public string GoogleMapsUri { get; set; }
    public string WebsiteUri { get; set; }
    public List<Review> Reviews { get; set; }
    public OpeningHours RegularOpeningHours { get; set; }
    public List<Photo> Photos { get; set; }
    public string AdrFormatAddress { get; set; }
    public BusinessStatus? BusinessStatus { get; set; }
    public PriceLevel? PriceLevel { get; set; }
    public List<Attribution> Attributions { get; set; }
    public string IconMaskBaseUri { get; set; }
    public string IconBackgroundColor { get; set; }
    public OpeningHours CurrentOpeningHours { get; set; }
    public List<OpeningHours> CurrentSecondaryOpeningHours { get; set; }
    public List<OpeningHours> RegularSecondaryOpeningHours { get; set; }
    public LocalizedText EditorialSummary { get; set; }
    public PaymentOptions PaymentOptions { get; set; }
    public ParkingOptions ParkingOptions { get; set; }
    public List<SubDestination> SubDestinations { get; set; }
    public FuelOptions FuelOptions { get; set; }
    public EVChargeOptions EvChargeOptions { get; set; }
    public GenerativeSummary GenerativeSummary { get; set; }
    public List<ContainingPlace> ContainingPlaces { get; set; }
    public AddressDescriptor AddressDescriptor { get; set; }
    public GoogleMapsLinks GoogleMapsLinks { get; set; }
    public PriceRange PriceRange { get; set; }
    public ReviewSummary ReviewSummary { get; set; }
    public EvChargeAmenitySummary EvChargeAmenitySummary { get; set; }
    public NeighborhoodSummary NeighborhoodSummary { get; set; }
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
    public AccessibilityOptions AccessibilityOptions { get; set; }
    public bool? PureServiceAreaBusiness { get; set; }
}