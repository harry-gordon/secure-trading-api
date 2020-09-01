using Newtonsoft.Json;
using SecureTradingApi.Enums;
using SecureTradingApi.Models.Abstract;

namespace SecureTradingApi.Models
{
    public class TokeniseAuthRequestModel : BaseInnerRequest
    {
        public TokeniseAuthRequestModel() : base(RequestTypeDescriptionEnum.AUTH) 
        {
        }

        [JsonProperty("paymenttypedescription")]
        public string PaymentTypeDescription { get; set; }
        [JsonProperty("sitereference")]
        public string SiteReference { get; set; }
        [JsonProperty("expirydate")]
        public string ExpiryDate { get; set; }
        [JsonProperty("securitycode")]
        public string SecurityCode { get; set; }
        [JsonProperty("orderreference")]
        public string OrderReference { get; set; }
        [JsonProperty("pan")]
        public string CardNumber { get; set; }

        [JsonProperty("baseamount")]
        public string Amount { get; set; }

        [JsonProperty("parenttransactionreference")]
        public string ParentTransactionReference { get; set; }
    }
}