using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace prmToolkit.Configuration
{
    public class Configuration
    {
        public static string GetKeyAppSettings(string key)
        {
            var value = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(value))
            {
                throw new Exception($"Chave '{key}' não definida na tag APPSETTINGS. Verifique seu WebConfig ou AppConfig.");
            }

            return value;
        }

        public static string GetConnectionString(string key)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[key]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception($"Chave '{key}' não definida na tag CONNECTIONSTRINGS. Verifique seu WebConfig ou AppConfig.");
            }

            return connectionString;
        }
    }
}
