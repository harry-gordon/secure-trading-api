using SecureTradingApi.Models.Abstract;

namespace SecureTradingApi.Models
{
    public class ErrorResponse : SecureTradingResponse<ErrorResponse.InnerResponse>
    {
        public class InnerResponse : BaseInnerResponse { }
    }
}
