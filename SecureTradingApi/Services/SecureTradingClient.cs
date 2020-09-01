using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SecureTradingApi.Exceptions;
using SecureTradingApi.Models;
using SecureTradingApi.Models.Abstract;

namespace SecureTradingApi.Services
{
    public class SecureTradingClient : ISecureTradingClient
    {
        #region Fields
        private readonly HttpClient _httpClient;
        private readonly SecureTradingConfigurationModel _config;
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        #endregion

        #region Constructors
        public SecureTradingClient(SecureTradingConfigurationModel config)
        {
            _httpClient = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes($"{config.Username}:{config.Password}");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            _config = config;
        }

        public async Task<TransactionQueryResponseModel> QueryAsync(TransactionQueryRequestModel innerRequest)
        {
            var request = BuildRequest(innerRequest);
            var response =
                await PostAsync<SecureTradingRequest<TransactionQueryRequestModel>,
                    SecureTradingResponse<TransactionQueryResponseModel>>(request);
            return response.Response;
        }
        #endregion

        #region Public Methods
        public async Task<AuthResponseModel> AuthAsync(AuthRequestModel innerRequest)
        {
            innerRequest.SiteReference = _config.SiteReference;
            return await RequestAsync<AuthRequestModel, AuthResponseModel>(innerRequest);
        }

        public async Task<AuthResponseModel> TokeniseAutheAsync(TokeniseAuthRequestModel innerRequest)
        {
            innerRequest.SiteReference = _config.SiteReference;
            return await RequestAsync<TokeniseAuthRequestModel, AuthResponseModel>(innerRequest);
        }

        public async Task<RefundResponseModel> RefundAsync(RefundRequestModel innerRequest)
        {
            innerRequest.SiteReference = _config.SiteReference;
            return await RequestAsync<RefundRequestModel, RefundResponseModel>(innerRequest);
        }

        public async Task<TransactionQueryResponseModel> TransactionQueryAsync(TransactionQueryRequestModel innerRequest)
        {
            return await RequestAsync<TransactionQueryRequestModel, TransactionQueryResponseModel>(innerRequest);
        }

        public async Task<RefundResponseModel> PayoutAsync(PayoutRequest request)
        {
            return await RequestAsync<PayoutRequest, RefundResponseModel>(request);
        }

        public async Task<TransactionUpdateResponse> UpdateTransactionAsync(TransactionUpdateRequest request)
        {
            return await RequestAsync<TransactionUpdateRequest, TransactionUpdateResponse>(request);
        }

        public async Task<CacheTokeniseResponse> CacheTokeniseAsync(CacheTokeniseRequest request)
        {
            return await RequestAsync<CacheTokeniseRequest, CacheTokeniseResponse>(request);
        }
        #endregion

        #region Private Methods
        private async Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest innerRequest)
            where TRequest : BaseInnerRequest
            where TResponse : BaseInnerResponse
        {
            var request = BuildRequest(innerRequest);
            var response =
                await PostAsync<SecureTradingRequest<TRequest>,
                    SecureTradingResponse<TResponse>>(request);
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

            if (innerResponse.IsError())
            {
                var message = $"ST returned an error response: {innerResponse.ErrorMessage} ({innerResponse.ErrorCode})";
                if (innerResponse.ErrorData.Any())
                {
                    message = $"{message}: {string.Join(",", innerResponse.ErrorData)}";
                }
                throw new SecureTradingException(errorResponse, message);
            }

            if (errorResponse.Responses.Length != 1)
            {
                throw new SecureTradingException(errorResponse, $"Unexpected number of responses in list ({errorResponse.Responses.Length})");
            }

            return json;
        }
        #endregion
    }
}