using LazyLofi.Backend.Manager;
using LazyLofi.Backend.Manager.ServiceLocators;
using LazyLofi.Backend.Manager.Services.Database.Models;
using System;
using System.Collections.Generic;

namespace LazyLofi.Backend
{
    public class BackendDomain
    {
        private readonly ServiceLocatorBase serviceLocator;

        private BackendManager backendManager;

        internal BackendDomain(ServiceLocatorBase serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        internal BackendManager BackendManager
        {
            get { return backendManager ?? (backendManager = serviceLocator.CreateBackendManager()); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BackendDomain"/> class.
        /// </summary>
        public BackendDomain() : this(new ServiceLocator())
        {
        }

        /// <summary>
        /// Gets the videos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<VideoDatabaseResposne> GetVideos(bool wantsToRefreshDatabase, string query)
        {
            try
            {
                var result = BackendManager.GetVideos(wantsToRefreshDatabase, query);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<VideoDatabaseResposne> GetVideos()
        {
            try
            {
                var result = BackendManager.GetVideos(false, string.Empty);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Setups the database.
        /// </summary>
        /// <returns></returns>
        public void SetupDatabase()
        {
            try
            {
                BackendManager.SetupDatabase();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}