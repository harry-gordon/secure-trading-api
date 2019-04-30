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
            
            var auth = await service.AuthAsync(new AuthRequest
            {
                BaseAmount = "1050",
                CacheToken = cacheToken.CacheToken,
                CurrencyIso3a = "GBP",
                OrderReference = orderReference,
                CredentialsOnFile = CredentialsOnFile.Store,
                SiteReference = secureTradingConfig.SiteReference
            });

            var query = await service.QueryAsync(new TransactionQueryRequest
            {
                Filter = new TransactionQueryFilter
                {
                    OrderReference = BuildValueList(orderReference),
                    SiteReference = BuildValueList(secureTradingConfig.SiteReference)
                }
            });

            var parentTransaction = query.Records.First(r => r.OrderReference == orderReference);

            var auth2 = await service.AuthAsync(new AuthRequest
            {
                BaseAmount = "1050",
                CurrencyIso3a = "GBP",
                OrderReference = orderReference,
                CredentialsOnFile = CredentialsOnFile.UseStored,
                ParentTransactionReference = parentTransaction.TransactionReference,
                SiteReference = secureTradingConfig.SiteReference
            });

            var refund = await service.PayoutAsync(new PayoutRequest
            {
                BaseAmount = "2100",
                CurrencyIso3a = "GBP",
                CredentialsOnFile = CredentialsOnFile.UseStored,
                ParentTransactionReference = parentTransaction.TransactionReference,
                SiteReference = secureTradingConfig.SiteReference
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
