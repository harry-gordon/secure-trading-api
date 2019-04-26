namespace SecureTradingApi.Models.Abstract
{
    public class SecureTradingRequest<TRequest> where TRequest : BaseInnerRequest
    {
        public string Alias { get; set; }
        public string Version { get; set; }
        public TRequest Request { get; set; }
    }
}
