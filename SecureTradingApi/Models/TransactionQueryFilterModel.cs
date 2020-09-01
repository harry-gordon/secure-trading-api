using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SecureTradingApi.Enums;

namespace SecureTradingApi.Models
{
    public class TransactionQueryFilterModel
    {
        [JsonProperty("sitereference")]
        public ValueWrapperModel[] SiteReference { get; set; }
        [JsonProperty("currencyiso3a")]
        public ValueWrapperModel[] CurrencyIso3a { get; set; }
        [JsonProperty("transactionreference")]
        public ValueWrapperModel[] TransactionReference { get; set; }
        [JsonProperty("accounttypedescription")]
        public ValueWrapperModel[] AccountTypeDescription { get; set; }

        [JsonProperty("billingemail")]
        public ValueWrapperModel[] BillingEmail { get; set; }
        [JsonProperty("billingfirstname")]
        public ValueWrapperModel[] BillingFirstName { get; set; }
        [JsonProperty("billinglastname")]
        public ValueWrapperModel[] BillingLastName { get; set; }
        [JsonProperty("billingpostcode")]
        public ValueWrapperModel[] BillingPostcode { get; set; }
        [JsonProperty("billingpremise")]
        public ValueWrapperModel[] BillingPremise { get; set; }

        [JsonProperty("customerip")]
        public ValueWrapperModel[] CustomerIp { get; set; }
        [JsonProperty("starttimestamp")]
        public ValueWrapperModel[] StartTime { get; set; }
        [JsonProperty("endtimestamp")]
        public ValueWrapperModel[] EndTime { get; set; }
        [JsonProperty("orderreference")]
        public ValueWrapperModel[] OrderReference { get; set; }
        [JsonProperty("pan")]
        public ValueWrapperModel[] CardNumber { get; set; }
        [JsonProperty("parenttransactionreference")]
        public ValueWrapperModel[] ParentTransactionReference { get; set; }
        [JsonProperty("paymenttypedescription")]
        public ValueWrapperModel[] PaymentTypeDescription { get; set; }

        [JsonProperty("requesttypedescription")]
        private ValueWrapperModel[] _requestTypeDescription =>
            RequestTypeDescription?.Select(t => new ValueWrapperModel {Value = t.ToString()}).ToArray();

        [JsonIgnore]
        public RequestTypeDescriptionEnum[] RequestTypeDescription { get; set; }
    }
}
