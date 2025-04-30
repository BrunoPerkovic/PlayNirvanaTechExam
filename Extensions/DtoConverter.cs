using PlayNirvanaTechExam.Dtos.Location;
using PlayNirvanaTechExam.Dtos.Place;
using PlayNirvanaTechExam.Entities;

namespace PlayNirvanaTechExam.Extensions;

public static class DtoConverter
{
    #region Place

    public static PlaceResponse ToResponse(this Place place)
    {
        return new PlaceResponse()
        {
            Id = place.Id,
            PlaceId = place.PlaceId,
            Name = place.Name ?? string.Empty,
            DisplayName = place.DisplayName ?? string.Empty,
            PrimaryType = place.PrimaryType ?? string.Empty,
            PrimaryTypeDisplayName = place.PrimaryTypeDisplayName ?? string.Empty,
            NationalPhoneNumber = place.NationalPhoneNumber ?? string.Empty,
            InternationalPhoneNumber = place.InternationalPhoneNumber ?? string.Empty,
            FormattedAddress = place.FormattedAddress ?? string.Empty,
            ShortFormattedAddress = place.ShortFormattedAddress ?? string.Empty,
            Revision = place.Revision ?? 0,
            RegionCode = place.RegionCode ?? string.Empty,
            LanguageCode = place.LanguageCode ?? string.Empty,
            PostalCode = place.PostalCode ?? string.Empty,
            SortingCode = place.SortingCode ?? string.Empty,
            AdministrativeArea = place.AdministrativeArea ?? string.Empty,
            Locality = place.Locality ?? string.Empty,
            Sublocality = place.Sublocality ?? string.Empty,
            GlobalCode = place.GlobalCode ?? string.Empty,
            CompoundCode = place.CompoundCode ?? string.Empty,
            Latitude = place.Latitude ?? 0,
            Longitude = place.Longitude ?? 0,
            Rating = place.Rating ?? 0,
            GoogleMapsUri = place.GoogleMapsUri ?? string.Empty,
            WebsiteUri = place.WebsiteUri ?? string.Empty,
            AdrFormatAddress = place.AdrFormatAddress ?? string.Empty,
            BusinessStatus = place.BusinessStatus ?? BusinessStatus.BUSINESS_STATUS_UNSPECIFIED,
            PriceLevel = place.PriceLevel ?? PriceLevel.PRICE_LEVEL_UNSPECIFIED,
            IconMaskBaseUri = place.IconMaskBaseUri ?? string.Empty,
            IconBackgroundColor = place.IconBackgroundColor ?? string.Empty,
            UtcOffsetMinutes = place.UtcOffsetMinutes ?? 0,
            UserRatingCount = place.UserRatingCount ?? 0,
            Takeout = place.Takeout ?? false,
            Delivery = place.Delivery ?? false,
            DineIn = place.DineIn ?? false,
            CurbsidePickup = place.CurbsidePickup ?? false,
            Reservable = place.Reservable ?? false,
            ServesBreakfast = place.ServesBreakfast ?? false,
            ServesLunch = place.ServesLunch ?? false,
            ServesDinner = place.ServesDinner ?? false,
            ServesBeer = place.ServesBeer ?? false,
            ServesWine = place.ServesWine ?? false,
            ServesBrunch = place.ServesBrunch ?? false,
            ServesVegetarianFood = place.ServesVegetarianFood ?? false,
            OutdoorSeating = place.OutdoorSeating ?? false,
            LiveMusic = place.LiveMusic ?? false,
            MenuForChildren = place.MenuForChildren ?? false,
            ServesCocktails = place.ServesCocktails ?? false,
            ServesDessert = place.ServesDessert ?? false,
            ServesCoffee = place.ServesCoffee ?? false,
            GoodForChildren = place.GoodForChildren ?? false,
            AllowsDogs = place.AllowsDogs ?? false,
            Restroom = place.Restroom ?? false,
            GoodForGroups = place.GoodForGroups ?? false,
            GoodForWatchingSports = place.GoodForWatchingSports ?? false,
            PureServiceAreaBusiness = place.PureServiceAreaBusiness ?? false,
            LocationId = place.LocationId,
        };
    }

    public static List<PlaceResponse> ToResponse(this List<Place> places)
    {
        return places.Select(p => p.ToResponse())
            .ToList();
    }

    #endregion

    #region Location

    public static BaseLocationDto ToBaseLocationDto(this BaseLocation location)
    {
        return new BaseLocationDto()
        {
            Id = location.Id,
            Latitude = location.Latitude,
            Longitude = location.Longitude,
            Radius = location.Radius
        };
    }

    public static List<BaseLocationDto> ToBaseLocationDto(this List<BaseLocation> locations)
    {
        return locations.Select(l => l.ToBaseLocationDto())
            .ToList();
    }

    #endregion
}