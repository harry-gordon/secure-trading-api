using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SecureTradingApi.Enums;

namespace SecureTradingApi.Models.Abstract
{
    public abstract class BaseInnerRequest
    {
        [JsonProperty("requesttypedescriptions", ItemConverterType = typeof(StringEnumConverter))]
        protected RequestTypeDescription[] _requestTypeDescriptions { get; }

        protected BaseInnerRequest(RequestTypeDescription requestTypeDescription)
        {
            _requestTypeDescriptions = new [] { requestTypeDescription };
        }
    }
}
