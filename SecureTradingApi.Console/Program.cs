using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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
            var configuration = GetConfiguration();
            SecureTradingConfigurationModel secureTradingConfig = new SecureTradingConfigurationModel
            {
                Alias = configuration["SecureTrading:Alias"],
                SiteReference = configuration["SecureTrading:SiteReference"],
                Endpoint = configuration["SecureTrading:Endpoint"],
                Username = configuration["SecureTrading:Username"],
                Password = configuration["SecureTrading:Password"],
                Version = "1.00"
            };
            SecureTradingClient service = new SecureTradingClient(secureTradingConfig);

            var orderReference = Guid.NewGuid().ToString();
            AuthResponseModel auth = await service.AuthAsync(new AuthRequestModel
            {
                BaseAmount = "1050",
                PAN = "4111111111111111",
                CVV = "123",
                Expiry = "12/2020",
                Currency = "GBP",
                OrderReference = orderReference,
            });

            System.Console.WriteLine("Hello World!");
        }

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}