using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SecureTradingApi.Enums;
using SecureTradingApi.Models;
using SecureTradingApi.Services;

namespace SecureTradingApi.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            System.Console.WriteLine("Hello World!");

            var configuration = GetConfiguration();

            var secureTradingConfig = new SecureTradingConfiguration
            {
                Alias = configuration["SecureTrading:Alias"],
                SiteReference = configuration["SecureTrading:SiteReference"],
                Endpoint = configuration["SecureTrading:Endpoint"],
                Username = configuration["SecureTrading:Username"],
                Password = configuration["SecureTrading:Password"],
                Version = "1.00"
            };

            var httpClient = new HttpClient();
            var service = new SecureTradingClient(httpClient, secureTradingConfig);

            var byteArray = Encoding.ASCII.GetBytes($"{secureTradingConfig.Username}:{secureTradingConfig.Password}");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

#if false
            var cacheToken = "eyJkYXRhY2VudGVydXJsIjogImh0dHBzOi8vd2Vic2VydmljZXMuc2VjdXJldHJhZGluZy5uZXQiLCAiY2FjaGV0b2tlbiI6ICI2LWI3MTUwMzRjNTQ0ZGRmOWVkNDI2MGYxNmNmYTgzYzA1YjQwM2UxNDAyN2FjZTRlNjlmOWRjN2RlNGIzMDA2MDEifQ==";

            var orderReference = Guid.NewGuid().ToString();

            // AUTH a payment
            var auth = await service.AuthAsync(new AuthRequest()
            {
                BaseAmount = "1050",
                CacheToken = cacheToken,
                CurrencyIso3a = "GBP",
                OrderReference = orderReference,
                SiteReference = secureTradingConfig.SiteReference
            });

            // Find that payment in queries
            var query = await service.QueryAsync(new TransactionQueryRequest
            {
                Filter = new TransactionQueryFilter
                {
                    CurrencyIso3a = BuildValueList("GBP"),
                    OrderReference = BuildValueList(orderReference)
                }
            });

            var transaction = query.Records.First();

            // Use that payment as parent for a payout
            var refund = await service.PayoutAsync(new PayoutRequest
            {
                ParentTransactionReference = transaction.TransactionReference,
                BaseAmount = "1050",
                CurrencyIso3a = "GBP",
                SiteReference = secureTradingConfig.SiteReference
            });
#endif

#if true
            var orderReference = Guid.NewGuid().ToString();

            var cacheToken = await service.CacheTokeniseAsync(new CacheTokeniseRequest
            { 
                CardNumber = "4111111111111111",
                ExpiryDate = "12/2024",
                OrderReference = orderReference,
                PaymentTypeDescription = "VISA",
                SecurityCode = "123",
                SiteReference = secureTradingConfig.SiteReference
            });

            var refund = await service.PayoutAsync(new PayoutRequest
            {
                CacheToken = cacheToken.CacheToken,
                BaseAmount = "100",
                CurrencyIso3a = "GBP",
                SiteReference = secureTradingConfig.SiteReference
            });

            var query = await service.QueryAsync(new TransactionQueryRequest
            {
                Filter = new TransactionQueryFilter
                {
                    AccountTypeDescription = BuildValueList(AccountTypeDescription.CFT.ToString())
                }
            });
#endif

#if false
            var queryA = await service.QueryAsync(new TransactionQueryRequest
            {
                Filter = new TransactionQueryFilter
                {
                    AccountTypeDescription = BuildValueList(AccountTypeDescription.ECOM.ToString())
                }
            });
#endif
        }

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }

        private static ValueWrapper[] BuildValueList(params string[] values)
        {
            return values.Select(v => new ValueWrapper {Value = v}).ToArray();
        }
    }
}
