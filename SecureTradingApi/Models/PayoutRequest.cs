using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SecureTradingApi.Enums;

namespace SecureTradingApi.Models
{
    public class PayoutRequest : RefundRequest
    {
        [JsonProperty("accounttypedescription")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountTypeDescription AccountTypeDescription => AccountTypeDescription.CFT;
    }
}
