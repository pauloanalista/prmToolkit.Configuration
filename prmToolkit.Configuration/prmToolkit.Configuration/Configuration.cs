using System;
using System.Configuration;

namespace prmToolkit.Configuration
{
    public class Configuration
    {
        /// <summary>
        /// Obtém valor definido no AppSettings pela chave.
        /// </summary>
        /// <param name="key">Chave definida no AppSettings</param>
        /// <returns>Valor da chave definida no AppSettings</returns>
        public static string GetKeyAppSettings(string key)
        {
            var value = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(value))
            {
                throw new Exception($"Chave '{key}' não definida na tag APPSETTINGS. Verifique seu WebConfig ou AppConfig.");
            }

            return value;
        }

        /// <summary>
        /// Obtém a string de conexão de um arquivo de configuração pelo nome.
        /// </summary>
        /// <param name="key">Chave definida no connectionStrings</param>
        /// <returns>Retorna a string de conexão</returns>
        public static string GetConnectionString(string key)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[key]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception($"Chave '{key}' não definida na tag CONNECTIONSTRINGS. Verifique seu WebConfig ou AppConfig.");
            }

            return connectionString;
        }

        /// <summary>
        /// Obtém o valor da chave definida no appsettings do arquivo de configuração já protegido.
        /// Este metodo descriptografa o arquivo de configuração, obtém a informação e criptografa o arquivo novamente.
        /// </summary>
        /// <param name="key">Chave definida no AppSettings</param>
        /// <returns>Valor da chave definida no AppSettings</returns>
        public static string GetKeyAppSettingsProtected(string key)
        {
            UnprotectConfigurationFile();

            var value = ConfigurationManager.AppSettings[key];

            ProtectConfigurationFile();

            if (string.IsNullOrEmpty(value))
            {
                throw new Exception($"Chave '{key}' não definida na tag APPSETTINGS. Verifique seu WebConfig ou AppConfig.");
            }

            return value;
        }

        /// <summary>
        /// Obtém a string de conexão de um arquivo de configuração já protegido.
        /// Este metodo descriptografa o arquivo de configuração, obtém a informação e criptografa o arquivo novamente.
        /// </summary>
        /// <param name="key">Chave definida no connectionStrings</param>
        /// <returns>Retorna a string de conexão</returns>
        public static string GetConnectionStringProtected(string key)
        {
            UnprotectConfigurationFile();

            var connectionString = ConfigurationManager.ConnectionStrings[key]?.ConnectionString;

            ProtectConfigurationFile();

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception($"Chave '{key}' não definida na tag CONNECTIONSTRINGS. Verifique seu WebConfig ou AppConfig.");
            }

            return connectionString;
        }

        /// <summary>
        /// Criptografa o arquivo de configuração App.Config / Web.Config
        /// </summary>
        public static void ProtectConfigurationFile()
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ConfigurationSection section = config.ConnectionStrings;

            if (!section.SectionInformation.IsProtected)
            {
                section.SectionInformation.ProtectSection("RSAProtectedConfigurationProvider");
                section.SectionInformation.ForceSave = true;
                config.Save();
            }
        }

        /// <summary>
        /// Descriptografa o arquivo de configuração App.Config / Web.Config
        /// </summary>
        public static void UnprotectConfigurationFile()
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ConnectionStringsSection section = config.ConnectionStrings;

            if (section.SectionInformation.IsProtected)
            {
                section.SectionInformation.UnprotectSection();
                section.SectionInformation.ForceSave = true;
                config.Save();
            }
        }
    }
}
