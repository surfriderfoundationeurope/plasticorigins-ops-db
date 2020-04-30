using System;
using Data.SchemaMigrator.Models.PgContext.Campaign;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace Data.SchemaMigrator
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static string GetConnectionString(){
            if(Environment.GetEnvironmentVariable("AzureConnectionString") != null) {
                var configuration = new ConfigurationBuilder()
                .AddAzureAppConfiguration(Environment.GetEnvironmentVariable("AzureConnectionString"))
                .Build();
                return configuration["SurfriderDb:AzureSQLServer"];
            }else {
                var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.local.json")
                .Build();
                return configuration.GetConnectionString("PostgreSql");
            }
        }
    }
}

