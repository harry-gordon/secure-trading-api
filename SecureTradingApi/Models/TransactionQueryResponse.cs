using Newtonsoft.Json;
using SecureTradingApi.Models.Abstract;

namespace SecureTradingApi.Models
{
    public class TransactionQueryResponse : BaseInnerResponse
    {
        public int Found { get; set; }
        public TransactionQueryRecord[] Records { get; set; } = new TransactionQueryRecord[0];
    }

    public class TransactionQueryRecord
    {
        [JsonProperty("tid")]
        public string TransactionId { get; set; }
    }
}
