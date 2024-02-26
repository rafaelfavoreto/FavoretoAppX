using System.ComponentModel;
using System.Reflection;

namespace FavoretoAppX.Domain.Resources;

public static class ResourcesEnum
{
    public static string GetDescription(this System.Enum value)
    {
        var field = value.GetType().GetField(value.ToString());

        if (field == null) return value.ToString();

        var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
        return attribute != null ? attribute.Description : value.ToString();
    }
}