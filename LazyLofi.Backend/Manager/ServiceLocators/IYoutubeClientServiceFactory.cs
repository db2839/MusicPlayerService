using Google.Apis.YouTube.v3;

namespace LazyLofi.Backend.Manager.ServiceLocators
{
    internal interface IYoutubeClientServiceFactory
    {
        YouTubeService CreateYoutubeService(string apikey);
    }
}