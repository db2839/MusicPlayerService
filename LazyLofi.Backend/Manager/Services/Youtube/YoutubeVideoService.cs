using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using LazyLofi.Backend.Manager.Constants;
using LazyLofi.Backend.Manager.ServiceLocators;
using LazyLofi.Backend.Manager.Services.Youtube.Models;
using System;
using System.Collections.Generic;

namespace LazyLofi.Backend.Manager.Services.Youtube
{
    internal sealed class YoutubeVideoService
    {
        private readonly YouTubeService youTubeService;

        /// <summary>
        /// Creates the youtube service.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="youtubeClientServiceFactory">The youtube client service factory.</param>
        /// <returns></returns>
        private static YouTubeService CreateYoutubeService(string apiKey, IYoutubeClientServiceFactory youtubeClientServiceFactory)
            => youtubeClientServiceFactory.CreateYoutubeService(apiKey);

        /// <summary>
        /// Maps to videos.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        private IEnumerable<VideoModel> MapToVideos(SearchListResponse result)
        {
            foreach (var searchResult in result.Items)
            {
                if (!this.VerifySearchResultIsValid(searchResult))
                {
                    continue;
                }

                yield return new VideoModel()
                {
                    Ttile = searchResult.Snippet.Title,
                    Url = $"https://www.youtube.com/embed/{searchResult.Id.VideoId}"
                };
            }
        }

        /// <summary>
        /// Verifies the search result is valid.
        /// </summary>
        /// <param name="searchResult">The search result.</param>
        /// <returns></returns>
        private bool VerifySearchResultIsValid(SearchResult searchResult) => searchResult.Id.Kind.Equals("youtube#video") && searchResult.Snippet.Title != null && searchResult.Id.VideoId != null;

        /// <summary>
        /// Initializes a new instance of the <see cref="YoutubeVideoService"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="youtubeServiceHandlerFactory">The youtube service handler factory.</param>
        public YoutubeVideoService(string apiKey, IYoutubeClientServiceFactory youtubeServiceHandlerFactory)
        {
            this.youTubeService = CreateYoutubeService(apiKey, youtubeServiceHandlerFactory);
        }

        /// <summary>
        /// Gets the videos.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Error: " + ex.Message</exception>
        public IEnumerable<VideoModel> GetVideos(string query = VideoSearchConstants.Chillhop)
        {
            var searchListRequest = youTubeService.Search.List("snippet");

            SearchListResponse searchListResponse;
            try
            {
                searchListRequest.Q = query; // Replace with your search term.
                searchListRequest.MaxResults = 50;
                searchListRequest.VideoEmbeddable = SearchResource.ListRequest.VideoEmbeddableEnum.True__;
                searchListRequest.VideoDefinition = SearchResource.ListRequest.VideoDefinitionEnum.High;
                searchListRequest.Type = "video";
                searchListResponse = searchListRequest.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return this.MapToVideos(searchListResponse);
        }
    }
}