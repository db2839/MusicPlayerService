using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using LazyLofi.Backend.Manager.Configuration;
using LazyLofi.Backend.Manager.Services.Database;
using LazyLofi.Backend.Manager.Services.Youtube;
using System.Net.Http;

namespace LazyLofi.Backend.Manager.ServiceLocators
{
    internal sealed class ServiceLocator : ServiceLocatorBase
    {
        protected override BackendManager CreateBackendManagerCore()
        {
            return new BackendManager(this);
        }

        protected override ConfigurationBase CreateConfigProviderCore()
        {
            return new ConfigurationProvider();
        }

        protected override DatabaseClient CreateDatabaseClientCore(string connectionString)
        {
            return new DatabaseClient(connectionString);
        }

        protected override DatabaseService CreateDatabaseServiceCore()
        {
            return new DatabaseService(this);
        }

        protected override HttpMessageHandler CreateHttpMessageHandlerCore()
        {
            return new HttpClientHandler();
        }

        protected override YouTubeService CreateYoutubeServiceCore(string apikey)
        {
            return new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = apikey,
                ApplicationName = this.GetType().ToString(),
            });
        }

        protected override YoutubeVideoService CreateYoutubeVideoServiceCore(string apikey)
        {
            return new YoutubeVideoService(apikey, this);
        }
    }
}