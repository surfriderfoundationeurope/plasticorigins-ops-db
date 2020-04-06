using System;
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
            var configuration = new ConfigurationBuilder().
            AddAzureAppConfiguration(Environment.GetEnvironmentVariable("AzureSQLServerConnectionString"))
            .Build();
            
            var rawContextCs = configuration["SurfriderDb:AzureSQLServer"];
            Console.WriteLine(rawContextCs ?? "Hello world!");
        }
    }
}

