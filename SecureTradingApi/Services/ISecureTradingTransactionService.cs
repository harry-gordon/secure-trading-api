using System.Threading.Tasks;
using SecureTradingApi.Models;

namespace SecureTradingApi.Services
{
    public interface ISecureTradingTransactionService
    {
        Task<TransactionQueryResponse> QueryAsync(TransactionQueryRequest request);
    }
}
