using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SecureTradingApi.Enums;

namespace SecureTradingApi.Models.Abstract
{
    public abstract class BaseInnerResponse
    {
        [JsonProperty("errormessage")]
        public string ErrorMessage { get; set; }
        [JsonProperty("errordata")]
        public string[] ErrorData { get; set; } = new string[0];
        [JsonProperty("errorcode")]
        public string ErrorCode { get; set; }
        [JsonProperty("requesttypedescription")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RequestTypeDescriptionEnum RequestTypeDescription { get; set; }
        [JsonProperty("transactionstartedtimestamp")]
        public DateTime TransactionStartedTime { get; set; }
    }
}
