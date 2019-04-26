
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SecureTradingApi.Enums;

namespace SecureTradingApi.Models.Abstract
{
    public abstract class BaseAuthResponse : BaseInnerResponse
    {
        [JsonProperty("tid")]
        public string TransactionId { get; set; }
        [JsonProperty("sitereference")]
        public string SiteReference { get; set; }
        public string Interface { get; set; }
        [JsonProperty("requesttypedescription")]
        public RequestTypeDescription RequestTypeDescription { get; set; }
        [JsonProperty("livestatus")]
        public LiveStatus LiveStatus { get; set; }
        public string Issuer { get; set; }
        [JsonProperty("dccenabled")]
        public int DccEnabled { get; set; }
        [JsonProperty("settleduedate")]
        public DateTime SettleDueDate { get; set; }
        [JsonProperty("errorcode")]
        public string ErrorCode { get; set; }
        [JsonProperty("baseamount")]
        public string BaseAmount { get; set; }
        [JsonProperty("securityresponsepostcode")]
        public SecurityResponse SecurityResponsePostcde { get; set; }
        [JsonProperty("transactionreference")]
        public string TransactionReference { get; set; }
        [JsonProperty("merchantname")]
        public string MerchantName { get; set; }
        [JsonProperty("paymenttypedescription")]
        public string PaymentTypeDescription { get; set; }
        [JsonProperty("orderreference")]
        public string OrderReference { get; set; }
        [JsonProperty("accounttypedescription")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountTypeDescription AccountTypeDescription { get; set; }
        [JsonProperty("fraudrating")]
        public int FraudRating { get; set; }
        [JsonProperty("splitfinalnumber")]
        public string SplitFinalNumber { get; set; }
        [JsonProperty("acquirerresponsecode")]
        public string AcquireResponseCode { get; set; }
        [JsonProperty("expirydate")]
        public string ExpiryDate { get; set; }
        [JsonProperty("securityresponsesecuritycode")]
        public string SecurityResponseSecurityCode { get; set; }
        [JsonProperty("currencyiso3a")]
        public string CurrencyIso3a { get; set; }
        [JsonProperty("authcode")]
        public string AuthCode { get; set; }
        [JsonProperty("settlebaseamount")]
        public string SettleBaseAmount { get; set; }
        [JsonProperty("errormessage")]
        public string ErrorMessage { get; set; }
        [JsonProperty("merchantcountryiso2a")]
        public string MerchantCountryIso2a { get; set; }
        [JsonProperty("maskedpan")]
        public string MaskedPan { get; set; }
        [JsonProperty("securityresponseaddress")]
        public string SecurityResponseAddress { get; set; }
        [JsonProperty("issuercountryiso2a")]
        public string IssuerCountryIso2a { get; set; }
        [JsonProperty("operatorname")]
        public string OperatorName { get; set; }
        [JsonProperty("SettleStatus")]
        public SettleStatus SettleStatus { get; set; }
    }
}
