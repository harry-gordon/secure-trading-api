using System.Threading.Tasks;
using SecureTradingApi.Models;

namespace SecureTradingApi.Services
{
    public interface ISecureTradingClient
    {
        Task<TransactionQueryResponseModel> QueryAsync(TransactionQueryRequestModel request);
        Task<AuthResponseModel> AuthAsync(AuthRequestModel request);
        Task<RefundResponseModel> PayoutAsync(PayoutRequest request);
        //Task<TransactionUpdateResponse> UpdateTransactionAsync(TransactionUpdateRequest request);
        Task<CacheTokeniseResponse> CacheTokeniseAsync(CacheTokeniseRequest request);
        Task<AuthResponseModel> TokeniseAutheAsync(TokeniseAuthRequestModel innerRequest);
        Task<RefundResponseModel> RefundAsync(RefundRequestModel innerRequest);
        Task<TransactionQueryResponseModel> TransactionQueryAsync(TransactionQueryRequestModel innerRequest);
    }
}
