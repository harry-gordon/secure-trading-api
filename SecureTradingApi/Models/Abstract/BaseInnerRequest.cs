using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SecureTradingApi.Enums;

namespace SecureTradingApi.Models.Abstract
{
    public abstract class BaseInnerRequest
    {
        [JsonProperty("requesttypedescriptions")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RequestTypeDescription[] RequestTypeDescriptions { get; set; }
    }
}
