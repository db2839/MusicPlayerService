using Google.Apis.YouTube.v3;
using LazyLofi.Backend.Manager.Configuration;
using LazyLofi.Backend.Manager.Services.Database;
using LazyLofi.Backend.Manager.Services.Youtube;
using System.Net.Http;

namespace LazyLofi.Backend.Manager.ServiceLocators
{
    /// <summary>
    /// Service Locator Base
    /// </summary>
    /// <seealso cref="LazyLofi.Backend.Manager.ServiceLocators.IHttpMessageHandlerFactory"/>
    /// <seealso cref="LazyLofi.Backend.Manager.ServiceLocators.IYoutubeClientServiceFactory"/>
    internal abstract class ServiceLocatorBase : IHttpMessageHandlerFactory, IYoutubeClientServiceFactory
    {
        protected abstract BackendManager CreateBackendManagerCore();

        protected abstract ConfigurationBase CreateConfigProviderCore();

        protected abstract DatabaseClient CreateDatabaseClientCore(string connectionString);

        protected abstract DatabaseService CreateDatabaseServiceCore();

        protected abstract HttpMessageHandler CreateHttpMessageHandlerCore();

        protected abstract YouTubeService CreateYoutubeServiceCore(string apikey);

        protected abstract YoutubeVideoService CreateYoutubeVideoServiceCore(string apikey);

        /// <summary>
        /// Creates the backend manager.
        /// </summary>
        /// <returns></returns>
        public BackendManager CreateBackendManager()
            => this.CreateBackendManagerCore();

        /// <summary>
        /// Creates the configuration provider.
        /// </summary>
        /// <returns></returns>
        public ConfigurationBase CreateConfigProvider()
            => this.CreateConfigProviderCore();

        /// <summary>
        /// Creates the database client.
        /// </summary>
        /// <returns></returns>
        public DatabaseClient CreateDatabaseClient(string connectionString)
            => this.CreateDatabaseClientCore(connectionString);

        /// <summary>
        /// Creates the database service.
        /// </summary>
        /// <returns></returns>
        public DatabaseService CreateDatabaseService()
            => this.CreateDatabaseServiceCore();

        /// <summary>
        /// Creates the HTTP message handler.
        /// </summary>
        /// <returns></returns>
        public HttpMessageHandler CreateHttpMessageHandler()
            => this.CreateHttpMessageHandlerCore();

        /// <summary>
        /// Creates the youtube service.
        /// </summary>
        /// <param name="apikey">The apikey.</param>
        /// <returns></returns>
        public YouTubeService CreateYoutubeService(string apikey)
            => this.CreateYoutubeServiceCore(apikey);

        /// <summary>
        /// Creates the youtube video service.
        /// </summary>
        /// <param name="apikey">The apikey.</param>
        /// <returns></returns>
        public YoutubeVideoService CreateYoutubeVideoService(string apikey)
            => this.CreateYoutubeVideoServiceCore(apikey);
    }
}