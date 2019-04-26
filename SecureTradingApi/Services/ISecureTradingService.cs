using System.Threading.Tasks;
using SecureTradingApi.Models;

namespace SecureTradingApi.Services
{
    public interface ISecureTradingService
    {
        Task<TransactionQueryResponse> QueryAsync(TransactionQueryRequest request);
        Task<AuthResponse> AuthAsync(AuthRequest request);
        Task<RefundResponse> PayoutAsync(PayoutRequest request);
    }
}
