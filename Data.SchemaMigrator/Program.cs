using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;

namespace Data.SchemaMigrator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetConnectionString());

        }

        public static string GetConnectionString()
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.local.json")
            .Build();

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Local")
                return GetKeyVaultConnectionString("db-plastico-dev-connectionstring");
            else
                return configuration.GetConnectionString("PostgreSql");
        }

        // https://docs.microsoft.com/en-us/azure/key-vault/secrets/quick-create-net
        public static string GetKeyVaultConnectionString(string secretName)
        {

            string keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME");
            var kvUri = "https://" + keyVaultName + ".vault.azure.net";

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            KeyVaultSecret secret = client.GetSecret(secretName);
            return secret.Value;
        }
    }
}

