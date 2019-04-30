using Newtonsoft.Json;

namespace SecureTradingApi.Models
{
    public class TransactionUpdateFilter
    {
        [JsonProperty("sitereference")]
        public string SiteReference { get; set; }
        [JsonProperty("transactionreference")]
        public string TransactionReference { get; set; }
    }
}
