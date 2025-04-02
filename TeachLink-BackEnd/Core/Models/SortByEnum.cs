using System.Text.Json.Serialization;

namespace TeachLink_BackEnd.Core.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SortByEnum
    {
        Rating,
        Reviews,
        PriceAsc,
        PriceDesc,
    }
}
