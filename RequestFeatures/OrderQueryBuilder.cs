using System.Reflection;
using System.Text;

namespace PlayNirvanaTechExam.RequestFeatures;

public static class OrderQueryBuilder
{
    public static string CreateOrderQuery<T>(string orderByQueryString)
    {
        var orderParams = orderByQueryString.Trim()
            .Split(',');
        var propertyInformation = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var orderQueryBuilder = new StringBuilder();

        foreach (var param in orderParams)
        {
            if (string.IsNullOrWhiteSpace(param))
            {
                continue;
            }
            
            var propertyFromQueryName = param.Split(" ")[0];
            var objectProperty = propertyInformation.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

            if (objectProperty == null)
            {
                continue;
            }
            
            var direction = param.EndsWith("desc") ? "descending" : "ascending";
            
            orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
        }

        var orderQuery = orderQueryBuilder.ToString()
            .TrimEnd(',', ' ');

        return orderQuery;
    }
}