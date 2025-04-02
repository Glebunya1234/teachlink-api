using System.Text.Json.Serialization;

namespace TeachLink_BackEnd.Core.ModelsMDB
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SortByEnumMDB
    {
        Rating,
        Reviews,
        PriceAsc,
        PriceDesc,
    }
}
