using SecureTradingApi.Enums;
using SecureTradingApi.Models.Abstract;

namespace SecureTradingApi.Models
{
    public class TransactionQueryRequestModel : BaseInnerRequest
    {
        public TransactionQueryFilterModel Filter { get; set; }

        public TransactionQueryRequestModel() : base(RequestTypeDescriptionEnum.TRANSACTIONQUERY)
        {
        }
    }
}