using Newtonsoft.Json;
using SecureTradingApi.Models.Abstract;

namespace SecureTradingApi.Models
{
    public class TransactionQueryResponse : BaseInnerResponse
    {
        public int Found { get; set; }
        public TransactionQueryRecord[] Records { get; set; } = new TransactionQueryRecord[0];
    }

    public class TransactionQueryRecord : BaseAuthResponse
    {
        [JsonProperty("updatereason")]
        public string UpdateReason { get; set; }
        [JsonProperty("sitereference")]
        public string SiteReference { get; set; }
        [JsonProperty("expirydate")]
        public string ExpiryDate { get; set; }
        [JsonProperty("fraudrating")]
        public int FraudRating { get; set; }
    }
}
