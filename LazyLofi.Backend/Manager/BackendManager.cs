using LazyLofi.Backend.Manager.ServiceLocators;
using LazyLofi.Backend.Manager.Services.Database;
using LazyLofi.Backend.Manager.Services.Database.Models;
using System.Collections.Generic;

namespace LazyLofi.Backend.Manager
{
    internal sealed class BackendManager
    {
        private DatabaseService databaseService;
        private ServiceLocator serviceLocator;

        internal DatabaseService DatabaseService
        {
            get
            {
                return databaseService ??
                    (databaseService
                    = serviceLocator.CreateDatabaseService());
            }
        }

        /// <summary>
        /// Gets the videos.
        /// </summary>
        /// <returns></returns>
        internal IEnumerable<VideoDatabaseResposne> GetVideos(bool wantsToRefreshDatabase, string query)
            => DatabaseService.GetVideos(wantsToRefreshDatabase, query);

        /// <summary>
        /// Setups the database.
        /// </summary>
        /// <returns></returns>
        internal void SetupDatabase()
            => DatabaseService.SetupDatabase();

        public BackendManager(ServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }
    }
}