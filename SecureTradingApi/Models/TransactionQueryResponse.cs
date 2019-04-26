using System;
using Newtonsoft.Json;
using SecureTradingApi.Models.Abstract;

namespace SecureTradingApi.Models
{
    public class TransactionQueryResponse : BaseResponse<TransactionQueryResponse.InnerResponse>
    {
        public class InnerResponse : BaseInnerResponse
        {
            public int Found { get; set; }
            public Record[] Records { get; set; } = new Record[0];
        }

        public class Record
        {
            [JsonProperty("tid")]
            public string TransactionId { get; set; }
        }
    }
}
