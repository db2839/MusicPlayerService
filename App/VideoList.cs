using System.Collections.Generic;
using LazyLofi.Backend.Manager.Services.Database.Models;

namespace LazyLofiDesktop
{
    public static class VideoList
    {
        private static List<VideoDatabaseResposne> videos;

        public static VideoDatabaseResposne GetVideo(int i) => videos[i];

        public static void SetVideos(List<VideoDatabaseResposne> vids)
        {
            videos = vids;
        }
    }
}