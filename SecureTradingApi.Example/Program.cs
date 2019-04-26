﻿using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SecureTradingApi.Enums;
using SecureTradingApi.Models;
using SecureTradingApi.Services;

namespace SecureTradingApi.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            Console.WriteLine("Hello World!");

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
            var service = new SecureTradingService(httpClient, secureTradingConfig);

            var byteArray = Encoding.ASCII.GetBytes($"{secureTradingConfig.Username}:{secureTradingConfig.Password}");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var cacheToken = "eyJkYXRhY2VudGVydXJsIjogImh0dHBzOi8vd2Vic2VydmljZXMuc2VjdXJldHJhZGluZy5uZXQiLCAiY2FjaGV0b2tlbiI6ICI0LTI3YjE0MTNiMzQwMmNhYTgyYTliZjk1ZTkxOWQ4ZTRlZTFjZGU4MjBmMTBmM2MzMjU3ZDFjYmJmZTI4MDdmYTgifQ==";

            var orderReference = Guid.NewGuid().ToString();

            var response = await service.QueryAsync(new TransactionQueryRequest
            {
                Filter = new TransactionQueryFilter
                {
                    CurrencyIso3a = BuildValueList("GBP"),
                    SiteReference = BuildValueList(secureTradingConfig.SiteReference)
                }
            });

            //var response = await service.AuthAsync(new AuthRequest()
            //{
            //    BaseAmount = "1050",
            //    CacheToken = cacheToken,
            //    CurrencyIso3a = "GBP",
            //    OrderReference = orderReference,
            //    SiteReference = secureTradingConfig.SiteReference
            //});
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
