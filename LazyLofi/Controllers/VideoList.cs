using LazyLofi.Backend.Manager.Services.Database.Models;
using System.Collections.Generic;

namespace LazyLofi.Controllers
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