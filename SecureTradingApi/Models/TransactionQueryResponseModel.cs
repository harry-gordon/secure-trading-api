using Newtonsoft.Json;
using SecureTradingApi.Models.Abstract;

namespace SecureTradingApi.Models
{
    public class TransactionQueryResponseModel : BaseInnerResponse
    {
        public int Found { get; set; }
        public TransactionQueryRecord[] Records { get; set; } = new TransactionQueryRecord[0];
    }

    public class TransactionQueryRecord : BaseAuthResponseModel
    {
        [JsonProperty("updatereason")]
        public string UpdateReason { get; set; }
        [JsonProperty("sitereference")]
        public string SiteReference { get; set; }
        [JsonProperty("fraudrating")]
        public int FraudRating { get; set; }
    }
}
