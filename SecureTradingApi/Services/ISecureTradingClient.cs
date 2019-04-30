using System.Threading.Tasks;
using SecureTradingApi.Models;

namespace SecureTradingApi.Services
{
    public interface ISecureTradingClient
    {
        Task<TransactionQueryResponse> QueryAsync(TransactionQueryRequest request);
        Task<AuthResponse> AuthAsync(AuthRequest request);
        Task<RefundResponse> PayoutAsync(PayoutRequest request);
        Task<TransactionUpdateResponse> UpdateTransactionAsync(TransactionUpdateRequest request);
        Task<CacheTokeniseResponse> CacheTokeniseAsync(CacheTokeniseRequest request);
    }
}
