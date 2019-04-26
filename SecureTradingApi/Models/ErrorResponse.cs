using SecureTradingApi.Models.Abstract;

namespace SecureTradingApi.Models
{
    public class ErrorResponse : BaseResponse<ErrorResponse.InnerResponse>
    {
        public class InnerResponse : BaseInnerResponse { }
    }
}
