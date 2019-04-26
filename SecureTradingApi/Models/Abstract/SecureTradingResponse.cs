using System.Linq;
using Newtonsoft.Json;

namespace SecureTradingApi.Models.Abstract
{
    public class SecureTradingResponse<TResponse> where TResponse : BaseInnerResponse 
    {
        [JsonProperty("requestreference")]
        public string RequestReference { get; set; }
        public string Version { get; set; }

        [JsonIgnore]
        public TResponse Response
        {
            get => Responses.FirstOrDefault();
            set => Responses = new[] {value};
        }

        [JsonProperty("response")]
        public TResponse[] Responses = new TResponse[0];
    }
}
