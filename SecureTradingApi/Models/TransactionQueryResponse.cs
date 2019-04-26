using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
    }
}
