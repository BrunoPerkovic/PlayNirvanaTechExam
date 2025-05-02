using System.Linq.Dynamic.Core;
using PlayNirvanaTechExam.Entities;

namespace PlayNirvanaTechExam.Repositories.Extensions;

public static class PlaceRepositoryExtension
{
    public static IQueryable<Place> FilterByProperties(this IQueryable<Place> places, IQueryCollection queryParams)
    {
        var propertyInfos = typeof(Place).GetProperties();
        var query = places;

        foreach (var param in queryParams)
        {
            var property = propertyInfos.FirstOrDefault(p =>
                p.Name.Equals(param.Key, StringComparison.OrdinalIgnoreCase));

            if (property == null) continue;

            var value = param.Value.ToString();
            if (string.IsNullOrEmpty(value)) continue;

            switch (Type.GetTypeCode(Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType))
            {
                case TypeCode.Boolean:
                    if (bool.TryParse(value, out bool boolValue))
                        query = query.Where($"{property.Name} == @0", boolValue);
                    break;

                case TypeCode.Int32:
                    if (int.TryParse(value, out int intValue))
                        query = query.Where($"{property.Name} == @0", intValue);
                    break;

                case TypeCode.Double:
                    if (double.TryParse(value, out double doubleValue))
                        query = query.Where($"{property.Name} == @0", doubleValue);
                    break;

                case TypeCode.String:
                    query = query.Where($"{property.Name}.ToLower().Contains(@0)", value.ToLower());
                    break;

                default:
                    if (property.PropertyType.IsEnum)
                    {
                        if (Enum.TryParse(property.PropertyType, value, true, out object enumValue))
                            query = query.Where($"{property.Name} == @0", enumValue);
                    }
                    break;
            }
        }

        return query;
    }
    public static IQueryable<Place> Search(this IQueryable<Place> places, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return places;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        return places.Where(p => 
            (p.Name != null && p.Name.ToLower().Contains(lowerCaseTerm)) ||
            (p.DisplayName != null && p.DisplayName.ToLower().Contains(lowerCaseTerm)) ||
            (p.PrimaryType != null && p.PrimaryType.ToLower().Contains(lowerCaseTerm)) ||
            (p.FormattedAddress != null && p.FormattedAddress.ToLower().Contains(lowerCaseTerm)));
    }
}