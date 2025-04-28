using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayNirvanaTechExam.Entities;

[Table("Places")]
public class Place
{
    [Key] public int PlaceId { get; set; }
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
    public virtual BaseLocation BaseLocation { get; set; }
}

public class LocalizedText
{
    public string Text { get; set; }
    public string LanguageCode { get; set; }
}

public class PostalAddress
{
    public int Revision { get; set; }
    public string RegionCode { get; set; }
    public string LanguageCode { get; set; }
    public string PostalCode { get; set; }
    public string SortingCode { get; set; }
    public string AdministrativeArea { get; set; }
    public string Locality { get; set; }
    public string Sublocality { get; set; }
    public List<string> AddressLines { get; set; }
    public List<string> Recipients { get; set; }
    public string Organization { get; set; }
}

public class AddressComponent
{
    public string LongName { get; set; }
    public string ShortName { get; set; }
    public List<string> Types { get; set; }
}

public class PlusCode
{
    public string GlobalCode { get; set; }
    public string CompoundCode { get; set; }
}

public class LatLng
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class Viewport
{
    public LatLng Low { get; set; }
    public LatLng High { get; set; }
}

public class Review
{
    public string Name { get; set; }
    public string RelativePublishTimeDescription { get; set; }
    public LocalizedText Text { get; set; }
    public LocalizedText OriginalText { get; set; }
    public int Rating { get; set; }
    public AuthorAttribution AuthorAttribution { get; set; }
    public string PublishTime { get; set; }
    public string FlagContentUri { get; set; }
    public string GoogleMapsUri { get; set; }
}

public class OpeningHours
{
    public List<Period> PeriodType { get; set; }
    public List<string> WeekdayDescriptions { get; set; }

    public SecondaryHoursType SecondaryHoursType { get; set; }
    public List<SpecialDay> SpecialDays { get; set; }
    public string NextOpenTime { get; set; }
    public string NextCloseTime { get; set; }
    public bool OpenNow { get; set; }
}

public class SpecialDay
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
}

public class Period
{
    public Point Open { get; set; }
    public Point Close { get; set; }
}

public class Point
{
    public SpecialDay Date { get; set; }
    public bool Truncated { get; set; }
    public int Day { get; set; }
    public int Hour { get; set; }
    public int Minute { get; set; }
}

public class TimeZone
{
    public string Id { get; set; }
    public string Version { get; set; }
}

public class Photo
{
    public string Name { get; set; }
    public int WidthPx { get; set; }
    public int HeightPx { get; set; }
    public List<AuthorAttribution> AuthorAttributions { get; set; }
    public string FlagContentUri { get; set; }
    public string GoogleMapsUri { get; set; }
}

public class AuthorAttribution
{
    public string DisplayName { get; set; }
    public string Uri { get; set; }
    public string PhotoUri { get; set; }
}

public class Attribution
{
    public string Provider { get; set; }
    public string ProviderUri { get; set; }
}

public class PaymentOptions
{
    public bool AcceptsCreditCards { get; set; }
    public bool AcceptsDebitCards { get; set; }
    public bool AcceptsCashOnly { get; set; }
    public bool AcceptsNfc { get; set; }
}

public class SubDestination
{
    public string Name { get; set; }
    public string Id { get; set; }
}

public class FuelOptions
{
    public List<FuelPrice> FuelPrices { get; set; }
}

public class FuelPrice
{
    public FuelType Type { get; set; }
    public Money Price { get; set; }
    public string UpdateTime { get; set; }
}

public class Money
{
    public string CurrencyCode { get; set; }
    public string Units { get; set; }
    public int Nanos { get; set; }
}

public class EVChargeOptions
{
    public int ConnectorCount { get; set; }
    public List<ConnectorAggregation> Connectors { get; set; }
}

public class ConnectorAggregation
{
    public EVConnectorType Type { get; set; }
    public int MaxChargeRateKw { get; set; }
    public int Count { get; set; }
    public string AvailabilityLastUpdateTime { get; set; }
    public int AvailableCount { get; set; }
    public int OutOfServiceCount { get; set; }
}

public class GenerativeSummary
{
    public LocalizedText Overview { get; set; }
    public string OverviewFlagContentUri { get; set; }
    public LocalizedText DisclosureText { get; set; }
}

public class ContainingPlace
{
    public string Name { get; set; }
    public string Id { get; set; }
}

public class AddressDescriptor
{
    public List<Landmark> Landmarks { get; set; }
    public List<Area> Areas { get; set; }

}

public class Landmark
{
    public string Name { get; set; }
    public string PlaceId { get; set; }
    public LocalizedText DisplayName { get; set; }
    public List<string> Types { get; set; }
    public SpatialRelationship SpatialRelationship { get; set; }
    public double StraightLineDistanceMeters { get; set; }
    public double TravelDistanceMeters { get; set; }
}


public class Area
{
    public string Name { get; set; }
    public string PlaceId { get; set; }
    public LocalizedText DisplayName { get; set; }
    public Containment Containment { get; set; }
}

public class GoogleMapsLinks
{
    public string DirectionsUri { get; set; }
    public string PlaceUri { get; set; }
    public string WriteAReviewUri { get; set; }
    public string ReviewsUri { get; set; }
    public string PhotosUri { get; set; }
}

public class PriceRange
{
    public Money StartPrice { get; set; }
    public Money EndPrice { get; set; }
}

public class ReviewSummary
{
    public LocalizedText Text { get; set; }
    public string FlagContentUri { get; set; }
    public LocalizedText DisclosureText { get; set; }
}

public class EvChargeAmenitySummary
{
    public ContentBlock Overview { get; set; }
    public ContentBlock Coffee { get; set; }
    public ContentBlock Restaurant { get; set; }
    public ContentBlock Store { get; set; }
    public string FlagContentUri { get; set; }
    public LocalizedText DisclosureText { get; set; }
}

public class ContentBlock
{
    public LocalizedText Content { get; set; }
    public List<string> ReferencedPlaces { get; set; }
}

public class NeighborhoodSummary
{
    public ContentBlock Overview { get; set; }
    public ContentBlock Description { get; set; }
    public string FlagContentUri { get; set; }
    public LocalizedText DisclosureText { get; set; }
}

public class ParkingOptions
{
    public bool FreeParkingLot { get; set; }
    public bool PaidParkingLot { get; set; }
    public bool FreeStreetParking { get; set; }
    public bool PaidStreetParking { get; set; }
    public bool ValetParking { get; set; }
    public bool FreeGarageParking { get; set; }
    public bool PaidGarageParking { get; set; }
}

public class AccessibilityOptions
{
    public bool WheelchairAccessibleEntrance { get; set; }
    public bool WheelchairAccessibleRestroom { get; set; }
    public bool WheelchairAccessibleSeating { get; set; }
    public bool WheelchairAccessibleParking { get; set; }
}