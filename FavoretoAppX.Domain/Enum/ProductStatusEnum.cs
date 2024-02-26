using System.ComponentModel;

namespace FavoretoAppX.Domain.Enum;

public enum ProductStatusEnum
{
    [Description("Product is active")]
    Active,
    [Description("Product is not active")]
    Disable
}
