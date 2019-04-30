using Newtonsoft.Json;
using SecureTradingApi.Enums;

namespace SecureTradingApi.Models
{
    public class TransactionUpdate
    {
        [JsonProperty("settlestatus")]
        public SettleStatus SettleStatus { get; set; }
        [JsonProperty("orderreference")]
        public string OrderReference { get; set; }
        [JsonProperty("settlebaseamount")]
        public string SettleBaseAmount { get; set; }
        [JsonProperty("settleduedate")]
        public string SettleDueDate { get; set; }
    }
}
