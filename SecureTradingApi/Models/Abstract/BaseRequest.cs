using System;
using System.Collections.Generic;
using System.Text;

namespace SecureTradingApi.Models.Abstract
{
    public abstract class BaseRequest<TRequest> where TRequest : BaseInnerRequest
    {
        public string Alias { get; set; }
        public string Version { get; set; }
        public TRequest Request { get; set; }
    }
}
