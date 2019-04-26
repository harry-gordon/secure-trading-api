using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SecureTradingApi.Enums;
using SecureTradingApi.Exceptions;
using SecureTradingApi.Models;
using SecureTradingApi.Models.Abstract;

namespace SecureTradingApi.Services
{
    public class SecureTradingService : ISecureTradingService
    {
        private readonly HttpClient _httpClient;
        private readonly SecureTradingConfiguration _config;

        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public SecureTradingService(HttpClient httpClient, SecureTradingConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<TransactionQueryResponse> QueryAsync(TransactionQueryRequest innerRequest)
        {
            var request = BuildRequest(innerRequest);
            var response =
                await PostAsync<SecureTradingRequest<TransactionQueryRequest>, 
                    SecureTradingResponse<TransactionQueryResponse>>(request);
            return response.Response;
        }

        public async Task<AuthResponse> AuthAsync(AuthRequest innerRequest)
        {
            var request = BuildRequest(innerRequest);
            var response =
                await PostAsync<SecureTradingRequest<AuthRequest>,
                    SecureTradingResponse<AuthResponse>>(request);
            return response.Response;
        }

        public async Task<RefundResponse> PayoutAsync(PayoutRequest innerRequest)
        {
            var request = BuildRequest(innerRequest);
            var response =
                await PostAsync<SecureTradingRequest<PayoutRequest>,
                    SecureTradingResponse<RefundResponse>>(request);
            return response.Response;
        }

        private SecureTradingRequest<TRequest> BuildRequest<TRequest>(TRequest innerRequest) where TRequest : BaseInnerRequest
        {
            return new SecureTradingRequest<TRequest>
            {
                Alias = _config.Alias,
                Version = _config.Version,
                Request = innerRequest
            };
        }

        private async Task<TResponse> GetAsync<TResponse>()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _config.Endpoint);
            return await GetResponseAsync<TResponse>(request);
        }

        private async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest data)
        {
            var request = new HttpRequestMessage(new HttpMethod("POST"), _config.Endpoint)
            {
                Content = GetJsonContent(data)
            };
            return await GetResponseAsync<TResponse>(request);
        }

        private StringContent GetJsonContent<TRequest>(TRequest request)
        {
            var json = JsonConvert.SerializeObject(request, _jsonSerializerSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private async Task<TResponse> GetResponseAsync<TResponse>(HttpRequestMessage request)
        {
            var json = await GetResponseJsonAsync(request);
            return JsonConvert.DeserializeObject<TResponse>(json);
        }

        private async Task<string> GetResponseJsonAsync(HttpRequestMessage request)
        {
            var response = await _httpClient.SendAsync(request);
            return await CheckResponseAsync(response);
        }

        private async Task<string> CheckResponseAsync(HttpResponseMessage response)
        {
            // SecureTrading don't use HTTP codes apparently but check them anyway
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(json);
            var innerResponse = errorResponse.Response;

            if (innerResponse.RequestTypeDescription == RequestTypeDescription.ERROR)
            {
                var message = $"ST returned an error response: {innerResponse.ErrorMessage} ({innerResponse.ErrorCode})";
                if (innerResponse.ErrorData.Any())
                {
                    message = $"{message}: {string.Join(',', innerResponse.ErrorData)}";
                }
                throw new SecureTradingException(errorResponse, message);
            }

            if (errorResponse.Responses.Length != 1)
            {
                throw new SecureTradingException(errorResponse, $"Unexpected number of responses in list ({errorResponse.Responses.Length})");
            }

            return json;
        }
    }
}