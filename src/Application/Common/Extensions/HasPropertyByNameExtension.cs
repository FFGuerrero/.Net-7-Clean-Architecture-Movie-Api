using System.Reflection;

namespace MovieApi.Application.Common.Extensions;
public static class HasPropertyByNameExtension
{
    public static (bool, string?) HasPropertyByName(this Type type, string propertyName)
    {
        string? propertyFullName = null;
        foreach (string part in propertyName.Split('.'))
        {
            PropertyInfo? propertyInfo = type.GetProperty(part, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo is null)
            {
                return (false, null);
            }

            propertyFullName = propertyFullName is null ? propertyInfo.Name : $"{propertyFullName}.{propertyInfo.Name}";
            type = propertyInfo.PropertyType;
        }

        bool propertyExists = propertyFullName is not null &&
            propertyFullName.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase);

        return (propertyExists, propertyFullName);
    }
}