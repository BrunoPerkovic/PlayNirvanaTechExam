using PlayNirvanaTechExam.Entities;
using PlayNirvanaTechExam.RequestFeatures;

namespace PlayNirvanaTechExam.Repositories.Extensions;

public static class PlaceRepositoryExtension
{
    public static IQueryable<Place> Search(this IQueryable<Place> places, string searchTerm)
{
    if (string.IsNullOrWhiteSpace(searchTerm))
    {
        return places;
    }

    // Parse the search term if it contains field specification
    string fieldToSearch = string.Empty;
    string valueToSearch = searchTerm;

    if (searchTerm.Contains("="))
    {
        var parts = searchTerm.Split('=');
        if (parts.Length == 2)
        {
            fieldToSearch = parts[0].Trim().ToLower();
            valueToSearch = parts[1].Trim().ToLower();
        }
    }

    // If specific field is provided, search only that field
    if (!string.IsNullOrEmpty(fieldToSearch))
    {
        return fieldToSearch switch
        {
            "regioncode" => places.Where(p => p.RegionCode.ToLower().Contains(valueToSearch)),
            "name" => places.Where(p => p.Name.ToLower().Contains(valueToSearch)),
            "primarytype" => places.Where(p => p.PrimaryType.ToLower().Contains(valueToSearch)),
            "locality" => places.Where(p => p.Locality.ToLower().Contains(valueToSearch)),
            _ => places.Where(p =>
                p.Name.ToLower().Contains(valueToSearch) ||
                p.DisplayName.ToLower().Contains(valueToSearch) ||
                p.PrimaryType.ToLower().Contains(valueToSearch) ||
                p.PrimaryTypeDisplayName.ToLower().Contains(valueToSearch) ||
                p.FormattedAddress.ToLower().Contains(valueToSearch) ||
                p.ShortFormattedAddress.ToLower().Contains(valueToSearch) ||
                p.RegionCode.ToLower().Contains(valueToSearch) ||
                p.LanguageCode.ToLower().Contains(valueToSearch) ||
                p.PostalCode.ToLower().Contains(valueToSearch) ||
                p.SortingCode.ToLower().Contains(valueToSearch) ||
                p.AdministrativeArea.ToLower().Contains(valueToSearch) ||
                p.Locality.ToLower().Contains(valueToSearch) ||
                p.Sublocality.ToLower().Contains(valueToSearch))
        };
    }

    // If no specific field, search all fields
    return places.Where(p =>
        p.Name.ToLower().Contains(valueToSearch) ||
        p.DisplayName.ToLower().Contains(valueToSearch) ||
        p.PrimaryType.ToLower().Contains(valueToSearch) ||
        p.PrimaryTypeDisplayName.ToLower().Contains(valueToSearch) ||
        p.FormattedAddress.ToLower().Contains(valueToSearch) ||
        p.ShortFormattedAddress.ToLower().Contains(valueToSearch) ||
        p.RegionCode.ToLower().Contains(valueToSearch) ||
        p.LanguageCode.ToLower().Contains(valueToSearch) ||
        p.PostalCode.ToLower().Contains(valueToSearch) ||
        p.SortingCode.ToLower().Contains(valueToSearch) ||
        p.AdministrativeArea.ToLower().Contains(valueToSearch) ||
        p.Locality.ToLower().Contains(valueToSearch) ||
        p.Sublocality.ToLower().Contains(valueToSearch)
    );
}
}