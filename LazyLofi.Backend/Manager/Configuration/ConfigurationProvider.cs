using Microsoft.Extensions.Configuration;

namespace LazyLofi.Backend.Manager.Configuration
{
    internal sealed class ConfigurationProvider : ConfigurationBase
    {
        private readonly IConfigurationRoot _configurationRoot;

        protected override string RetrieveAppSettings(string appSettingKey)
        {
            return this._configurationRoot["AppSettings:" + appSettingKey];
        }

        public ConfigurationProvider()
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("appsettings.Json");
            this._configurationRoot = configBuilder.Build();
        }

        public ConfigurationProvider(IConfigurationRoot configurationRoot)
        {
            this._configurationRoot = configurationRoot;
        }
    }
}