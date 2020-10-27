﻿using System;

namespace LazyLofi.Backend.Manager.Configuration
{
    public abstract class ConfigurationBase
    {
        private string RetrieveAppSettingsThrowIfMissing(string appSettingKey)
        {
            var appSettingValue = this.RetrieveAppSettings(appSettingKey);
            if (appSettingValue == null)
            {
                // TODO:Add better exceptions
                throw new Exception("Figure it out");
            }

            if (appSettingValue.Length == 0)
            {
                // TODO:Add better exceptions
                throw new Exception("Figure it out");
            }
            return appSettingValue;
        }

        protected abstract string RetrieveAppSettings(string appSettingKey);

        public string GetDatabaseConnectionString() => this.RetrieveAppSettingsThrowIfMissing("ConnectionString");

        public string GetYoutubeApiKey() => this.RetrieveAppSettingsThrowIfMissing("YoutubeApiKey");
    }
}